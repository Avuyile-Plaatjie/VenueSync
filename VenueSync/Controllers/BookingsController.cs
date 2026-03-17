using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VenueSync.Data;
using VenueSync.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace VenueSync.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔐 ADMIN CHECK
        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("Admin") != null;
        }

        // 🔹 INDEX
        public async Task<IActionResult> Index()
        {
            var bookings = _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue);

            return View(await bookings.ToListAsync());
        }

        // 🔹 CREATE (GET)
        public IActionResult Create()
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventName");
            ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName");

            return View();
        }

        // 🔹 CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            // 🔥 DOUBLE BOOKING VALIDATION
            bool isAlreadyBooked = _context.Bookings.Any(b =>
                b.VenueId == booking.VenueId &&
                b.BookingDate.Date == booking.BookingDate.Date
            );

            if (isAlreadyBooked)
            {
                ModelState.AddModelError("", "This venue is already booked for the selected date.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reload dropdowns if error
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventName", booking.EventId);
            ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", booking.VenueId);

            return View(booking);
        }

        // 🔹 EDIT (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null) return NotFound();

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventName", booking.EventId);
            ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", booking.VenueId);

            return View(booking);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id != booking.BookingId)
                return NotFound();

            // 🔥 DOUBLE BOOKING VALIDATION (exclude current booking)
            bool isAlreadyBooked = _context.Bookings.Any(b =>
                b.VenueId == booking.VenueId &&
                b.BookingDate.Date == booking.BookingDate.Date &&
                b.BookingId != booking.BookingId
            );

            if (isAlreadyBooked)
            {
                ModelState.AddModelError("", "This venue is already booked for the selected date.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventName", booking.EventId);
            ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", booking.VenueId);

            return View(booking);
        }

        // 🔹 DELETE (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null) return NotFound();

            var booking = await _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefaultAsync(m => m.BookingId == id);

            if (booking == null) return NotFound();

            return View(booking);
        }

        // 🔹 DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account");

            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
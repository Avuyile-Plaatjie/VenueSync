using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VenueSync.Data;
using VenueSync.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    private bool IsAdminLoggedIn()
    {
        return HttpContext.Session.GetString("Admin") != null;
    }

    // 🔹 INDEX ✅ (FIXED)
    public async Task<IActionResult> Index()
    {
        var events = _context.Events
            .Include(e => e.Venue);

        return View(await events.ToListAsync());
    }

    // CREATE
    public IActionResult Create()
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Event ev)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (ModelState.IsValid)
        {
            _context.Add(ev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", ev.VenueId);
        return View(ev);
    }

    // EDIT
    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id == null) return NotFound();

        var ev = await _context.Events.FindAsync(id);
        if (ev == null) return NotFound();

        ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", ev.VenueId);
        return View(ev);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Event ev)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id != ev.EventId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(ev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.VenueId = new SelectList(_context.Venues, "VenueId", "VenueName", ev.VenueId);
        return View(ev);
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id == null) return NotFound();

        var ev = await _context.Events
            .Include(e => e.Venue)
            .FirstOrDefaultAsync(e => e.EventId == id);

        if (ev == null) return NotFound();

        return View(ev);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        var ev = await _context.Events.FindAsync(id);
        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
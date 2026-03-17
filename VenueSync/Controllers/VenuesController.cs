using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenueSync.Data;
using VenueSync.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class VenuesController : Controller
{
    private readonly ApplicationDbContext _context;

    public VenuesController(ApplicationDbContext context)
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
        var venues = await _context.Venues.ToListAsync();
        return View(venues);
    }

    // CREATE
    public IActionResult Create()
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Venue venue)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (ModelState.IsValid)
        {
            _context.Add(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(venue);
    }

    // EDIT
    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id == null) return NotFound();

        var venue = await _context.Venues.FindAsync(id);
        if (venue == null) return NotFound();

        return View(venue);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Venue venue)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id != venue.VenueId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(venue);
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        if (id == null) return NotFound();

        var venue = await _context.Venues.FirstOrDefaultAsync(v => v.VenueId == id);
        if (venue == null) return NotFound();

        return View(venue);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Account");

        var venue = await _context.Venues.FindAsync(id);
        _context.Venues.Remove(venue);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VenueSync.Data;
using VenueSync.Models;
using System.Linq;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Login page
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login form
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var admin = _context.Admins
            .FirstOrDefault(a => a.Username == username && a.Password == password);

        if (admin != null)
        {
            HttpContext.Session.SetString("Admin", admin.Username);
            return RedirectToAction("Index", "Venues");
        }

        ViewBag.Error = "Invalid username or password!";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Admin");
        return RedirectToAction("Login");
    }
}
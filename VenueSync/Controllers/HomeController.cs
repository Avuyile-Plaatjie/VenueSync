using Microsoft.AspNetCore.Mvc;

namespace VenueSync.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
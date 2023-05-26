using Microsoft.AspNetCore.Mvc;

namespace ProiectPAW__MVC_.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

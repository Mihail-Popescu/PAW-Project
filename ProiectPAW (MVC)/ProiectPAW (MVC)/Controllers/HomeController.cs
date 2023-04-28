using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Models;

namespace ProiectPAW__MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Mobile()
        {
            return View();
        }

        public IActionResult Television()
        {
            return View();
        }

        public IActionResult Internet()
        {
            return View();
        }

        public IActionResult Phones()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult AccountDetails()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

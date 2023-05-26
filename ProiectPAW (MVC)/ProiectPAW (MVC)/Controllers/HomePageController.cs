using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class HomepageController : Controller
    {
        private readonly HomepageService _homepageService;

        public HomepageController(HomepageService homepageService)
        {
            _homepageService = homepageService;
        }

        public IActionResult Homepage()
        {
            var secondPlans = _homepageService.GetSecondPlans();
            return View(secondPlans);
        }
    }
}
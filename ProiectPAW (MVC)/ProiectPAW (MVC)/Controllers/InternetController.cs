using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class InternetController : Controller
    {
        private readonly InternetService _internetService;

        public InternetController(InternetService internetService)
        {
            _internetService = internetService;
        }

        public IActionResult Internet()
        {
            var internetPlans = _internetService.GetInternetPlans();
            return View(internetPlans);
        }

    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class MobileController : Controller
    {
        private readonly MobileService _mobileService;

        public MobileController(MobileService mobileService)
        {
            _mobileService = mobileService;
        }

        public IActionResult Mobile()
        {
            var mobilePlans = _mobileService.GetMobilePlans();
            return View(mobilePlans);
        }

    }
}

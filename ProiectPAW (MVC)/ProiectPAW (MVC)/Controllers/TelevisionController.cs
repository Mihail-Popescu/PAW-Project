using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class TelevisionController : Controller
    {
        private readonly TelevisionService _televisionService;

        public TelevisionController(TelevisionService televisionService)
        {
            _televisionService = televisionService;
        }

        public IActionResult Television()
        {
            var televisionPlans = _televisionService.GetTelevisionPlans();
            return View(televisionPlans);
        }

    }
}

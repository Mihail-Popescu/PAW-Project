using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhonesService _phonesService;

        public PhonesController(PhonesService phonesService)
        {
            _phonesService = phonesService;
        }

        public IActionResult Phones()
        {
            var phones = _phonesService.GetPhones();
            return View(phones);
        }
    }
}

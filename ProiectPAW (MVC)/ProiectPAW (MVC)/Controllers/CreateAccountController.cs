using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class CreateAccountController : Controller
    {

        private readonly CreateAccountService _createAccountService;

        public CreateAccountController(CreateAccountService createAccountService)
        {
            _createAccountService = createAccountService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer, Address address, Card card)
        {
            if (ModelState.IsValid)
            {
                var result = await _createAccountService.CreateAccountAsync(customer, address, card);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the account");
                }
            }

            return View(customer);
        }


        public IActionResult CreateAccount()
        {
            return View();
        }
    }
}

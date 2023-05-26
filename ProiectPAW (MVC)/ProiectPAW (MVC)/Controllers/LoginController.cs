using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(ProiectPAWDbContext context)
        {
            _loginService = new LoginService(context);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [SessionAuthorize]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have successfully logged out!";
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Authenticate(string email, string password)
        {
            var admin = _loginService.AuthenticateAdmin(email, password);
            if (admin != null)
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("UserRole", "Admin");

                TempData["SuccessMessage"] = "You have successfully logged in!";

                // admin logged in
                return RedirectToAction("Index", "Home");
            }

            var customer = _loginService.AuthenticateCustomer(email, password);
            if (customer != null)
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("UserRole", "Customer");

                // Store CustomerId in session
                HttpContext.Session.SetInt32("CustomerId", customer.CustomerId);

                TempData["SuccessMessage"] = "You have successfully logged in!";

                // customer logged in
                return RedirectToAction("Index", "Home");
            }

            // authentication failed
            TempData["ErrorMessage"] = "Invalid email or password";
            return View("Login");
        }
    }
}
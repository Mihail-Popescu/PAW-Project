using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Services;
using System.Threading.Tasks;

namespace ProiectPAW__MVC_.Controllers
{
    [SessionAuthorize]
    public class AccountDetailsController : Controller
    {
        private readonly AccountDetailsService _accountDetailsService;

        public AccountDetailsController(AccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public async Task<IActionResult> AccountDetails()
        {
            int? accountId = 0;
            Customer account = null;
            // Retrieve the account details for the currently logged-in user
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId.HasValue)
            {
                accountId = customerId;
                account = await _accountDetailsService.GetAccountDetailsAsync((int)accountId);
            }
            else
            {
                accountId = 3;
                account = await _accountDetailsService.GetAccountDetailsAsync((int)accountId);
            }

            if (account != null)
            {
                return View("AccountDetails", account);
            }

            return View("AccountDetails");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(Customer updatedAccount)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            updatedAccount.CustomerId = (int)customerId;
            if (ModelState.IsValid)
            {
                // Update the account details
                var success = await _accountDetailsService.UpdateAccountDetailsAsync(updatedAccount);

                if (success)
                {
                    // Redirect to the account details page
                    return RedirectToAction("AccountDetails");
                }
            }

            // If the update was not successful or the model state is invalid, return to the account details view with the updated account object
            return View("AccountDetails", updatedAccount);
        }
    }
}

using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;
using ProiectPAW__MVC_.Services;

namespace ProiectPAW__MVC_.Services
{
    public class HomepageService
    {
        private readonly InternetService _internetService;
        private readonly MobileService _mobileService;
        private readonly TelevisionService _televisionService;

        public HomepageService(InternetService internetService, MobileService mobileService, TelevisionService televisionService)
        {
            _internetService = internetService;
            _mobileService = mobileService;
            _televisionService = televisionService;
        }

        public List<Product> GetSecondPlans()
        {
            // Retrieve the second plan from each service
            var internetPlans = _internetService.GetInternetPlans();
            var mobilePlans = _mobileService.GetMobilePlans();
            var televisionPlans = _televisionService.GetTelevisionPlans();

            // Get the second plan from each list
            var secondPlans = new List<Product>();
            if (internetPlans.Count >= 2)
            {
                secondPlans.Add(internetPlans[1]);
            }
            if (mobilePlans.Count >= 2)
            {
                secondPlans.Add(mobilePlans[1]);
            }
            if (televisionPlans.Count >= 2)
            {
                secondPlans.Add(televisionPlans[1]);
            }

            return secondPlans;
        }
    }
}

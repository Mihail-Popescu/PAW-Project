using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;
using System.Linq;

namespace ProiectPAW__MVC_.Services
{
    public class LoginService
    {
        private readonly AdminRepository _adminRepo;
        private readonly CustomerRepository _customerRepo;

        public LoginService(ProiectPAWDbContext context)
        {
            _adminRepo = new AdminRepository(context);
            _customerRepo = new CustomerRepository(context);
        }

        public Admin AuthenticateAdmin(string email, string password)
        {
            var admin = _adminRepo.GetAllAdmins().FirstOrDefault(x => x.Email == email && x.Password == password);
            return admin;
        }

        public Customer AuthenticateCustomer(string email, string password)
        {
            var customer = _customerRepo.GetAllCustomers().FirstOrDefault(x => x.Email == email && x.Password == password);
            return customer;
        }
    }
}

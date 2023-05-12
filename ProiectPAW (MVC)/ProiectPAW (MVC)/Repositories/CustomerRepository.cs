using System;
using System.Collections.Generic;
using System.Linq;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Data;

namespace ProiectPAW__MVC_.Repositories
{
    public class CustomerRepository
    {
        private readonly ProiectPAWDbContext _context;

        public CustomerRepository(ProiectPAWDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public void RemoveCustomer(int customerId)
        {
            var customer = _context.Customer.Find(customerId);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customer.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomerByEmailAndPassword(string email, string password)
        {
            return _context.Customer.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public Admin GetAdminByEmailAndPassword(string email, string password)
        {
            return _context.Admin.FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
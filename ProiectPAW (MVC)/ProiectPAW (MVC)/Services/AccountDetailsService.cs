using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;

namespace ProiectPAW__MVC_.Services
{
    public class AccountDetailsService
    {
        private readonly ProiectPAWDbContext _dbContext;

        public AccountDetailsService(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetAccountDetailsAsync(int Id)
        {
            try
            {
                var account = await _dbContext.Customer
                    .Include(a => a.Address)
                    .Include(a => a.Card)
                    .FirstOrDefaultAsync(a => a.CustomerId == Id);

                return account;
            }
            catch (Exception)
            {
                // Log the exception or handle it accordingly
                throw;
            }
        }

        public async Task<bool> UpdateAccountDetailsAsync(Customer updatedAccount)
        {
            try
            {
                var existingAccount = await _dbContext.Customer
                    .Include(a => a.Address)
                    .Include(a => a.Card)
                    .FirstOrDefaultAsync(a => a.CustomerId == updatedAccount.CustomerId);

                if (existingAccount == null)
                {
                    return false; // Account not found
                }

                // Update the account details
                existingAccount.FirstName = updatedAccount.FirstName;
                existingAccount.LastName = updatedAccount.LastName;
                existingAccount.PhoneNumber = updatedAccount.PhoneNumber;

                if (existingAccount.Address == null)
                {
                    existingAccount.Address = new Address(); // Initialize the Address object
                }

                existingAccount.Address.Country = updatedAccount.Address?.Country;
                existingAccount.Address.County = updatedAccount.Address?.County;
                existingAccount.Address.City = updatedAccount.Address?.City;
                existingAccount.Address.Postalcode = updatedAccount.Address?.Postalcode;
                existingAccount.Address.Block = updatedAccount.Address?.Block;
                existingAccount.Address.Floor = updatedAccount.Address?.Floor;
                existingAccount.Address.Apartment = updatedAccount.Address?.Apartment;
                existingAccount.Address.Staircase = updatedAccount.Address?.Staircase;
                existingAccount.Address.Street = updatedAccount.Address?.Street;

                if (existingAccount.Card == null)
                {
                    existingAccount.Card = new Card(); // Initialize the Card object
                }

                existingAccount.Card.Number = updatedAccount.Card?.Number;
                existingAccount.Card.Date = updatedAccount.Card?.Date;
                existingAccount.Card.CVV = updatedAccount.Card?.CVV;

                // Inform the change tracker that the existing account object has been modified
                _dbContext.Update(existingAccount);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception or handle it accordingly
                throw;
            }
        }

    }
}

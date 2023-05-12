using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;

namespace ProiectPAW__MVC_.Services
{
    public class CreateAccountService
    {
        private readonly ProiectPAWDbContext _dbContext;

        public CreateAccountService(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAccountAsync(Customer customer, Address address, Card card)
        {
            try
            {
                // Check if the email is already registered
                if (await _dbContext.Customer.AnyAsync(a => a.Email == customer.Email))
                {
                    return false;
                }

                // Create a new Account entity
                var account = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Password = customer.Password,
                    PhoneNumber = customer.PhoneNumber,
                    Image = await SaveProfileImageAsync(customer.Image),
                    Address = new Address
                    {
                        Country = address.Country,
                        County = address.County,
                        City = address.City,
                        Postalcode = address.Postalcode,
                        Block = address.Block,
                        Floor = address.Floor,
                        Apartment = address.Apartment,
                        Staircase = address.Staircase,
                        Street = address.Street,
                    },
                    Card = new Card
                    {
                        Number = card.Number,
                        Date = card.Date,
                        CVV = card.CVV,
                    },
                };

                // Add the new account to the database
                _dbContext.Customer.Add(account);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Log the exception and return false
                return false;
            }
        }

        private async Task<string> SaveProfileImageAsync(string profileImage)
        {
            if (!string.IsNullOrEmpty(profileImage))
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(profileImage);
                var filePath = Path.Combine("wwwroot/images/profiles", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(profileImage)))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }

                return fileName;
            }

            return null;
        }


    }
}

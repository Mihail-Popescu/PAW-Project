using System;
using System.Collections.Generic;
using System.Linq;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Data;

namespace ProiectPAW__MVC_.Repositories
{
    public class AddressRepository
    {
        private readonly ProiectPAWDbContext _context;

        public AddressRepository(ProiectPAWDbContext context)
        {
            _context = context;
        }

        public void AddAddress(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _context.Address.Update(address);
            _context.SaveChanges();
        }

        public void RemoveAddress(int addressId)
        {
            var address = _context.Address.Find(addressId);
            if (address != null)
            {
                _context.Address.Remove(address);
                _context.SaveChanges();
            }
        }

        public Address GetAddressById(int addressId)
        {
            return _context.Address.FirstOrDefault(a => a.AddressId == addressId);
        }

        public List<Address> GetAllAddresses()
        {
            return _context.Address.ToList();
        }
    }
}
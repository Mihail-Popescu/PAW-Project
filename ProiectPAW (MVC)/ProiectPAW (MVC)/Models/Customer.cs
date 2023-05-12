using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Metadata;

namespace ProiectPAW__MVC_.Models
{
        public class Customer
        {
            public int CustomerId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public int? PhoneNumber { get; set; }
            public string? Image { get; set; }
            public virtual Card? Card { get; set; }
            public int CardId { get; set; }

            public virtual Address? Address { get; set; }
            public int AddressId { get; set; }

            public virtual ICollection<Order>? Orders { get; set; }
        }
}

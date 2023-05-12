using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;

namespace ProiectPAW__MVC_.Repositories
{
    public class AdminRepository
    {
        private readonly ProiectPAWDbContext _context;

        public AdminRepository(ProiectPAWDbContext context)
        {
            _context = context;
        }
        public List<Admin> GetAllAdmins()
        {
            return _context.Admin.ToList();
        }
        public async Task<Admin> GetAdminByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Admin.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }

        public async Task<bool> IsAdminEmailAndPasswordValidAsync(string email, string password)
        {
            return await _context.Admin.AnyAsync(a => a.Email == email && a.Password == password);
        }
    }
}

using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProiectPAW__MVC_.Repositories
{
    public class ProductRepository
    {
        private readonly ProiectPAWDbContext _dbContext;

        public ProductRepository(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Product.Include(p => p.Category).ToList();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _dbContext.Product.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Product.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _dbContext.Product.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
        }

    }
}

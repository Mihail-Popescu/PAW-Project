using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProiectPAW__MVC_.Repositories
{
    public class CategoryRepository
    {
        private readonly ProiectPAWDbContext _dbContext;

        public CategoryRepository(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Category.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Category.FirstOrDefault(c => c.CategoryId == id);
        }
        public int GetCategoryIdByName(string categoryName)
        {
            return _dbContext.Category.FirstOrDefault(c => c.Name == categoryName)?.CategoryId ?? 0;
        }

    }

}

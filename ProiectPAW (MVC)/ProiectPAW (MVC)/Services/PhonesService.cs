using System.Collections.Generic;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;

namespace ProiectPAW__MVC_.Services
{
    public class PhonesService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public PhonesService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public List<Product> GetPhones()
        {
            var categoryId = _categoryRepository.GetCategoryIdByName("Phone");
            if (categoryId == 0)
            {
                return new List<Product>();
            }
            var products = _productRepository.GetProductsByCategoryId(categoryId);
            if (products == null)
            {
                return new List<Product>();
            }
            return products;
        }


    }
}

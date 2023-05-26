using System.Collections.Generic;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;

namespace ProiectPAW__MVC_.Services
{
    public class MobileService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public MobileService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public List<Product> GetMobilePlans()
        {
            var categoryId = _categoryRepository.GetCategoryIdByName("Mobile");
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

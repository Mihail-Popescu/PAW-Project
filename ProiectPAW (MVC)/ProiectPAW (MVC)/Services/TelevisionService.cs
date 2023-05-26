using System.Collections.Generic;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;

namespace ProiectPAW__MVC_.Services
{
    public class TelevisionService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public TelevisionService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public List<Product> GetTelevisionPlans()
        {
            var categoryId = _categoryRepository.GetCategoryIdByName("Television");
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

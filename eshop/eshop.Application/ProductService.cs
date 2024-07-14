using eshop.Entities;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll().AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            return productRepository.GetProductByCategory(categoryName).AsEnumerable();
        }
    }
}

﻿using eshop.Application.DataTransferObjects;
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

        public Product GetProduct(int id)
        {
            return productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll().AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            return productRepository.GetProductByCategory(categoryName).AsEnumerable();
        }

        public int CreateProduct(CreateProductRequest productRequest)
        {
            var product = new Product
            {
                CategoryId = productRequest.CategoryId,
                Description = productRequest.Description,
                ImageURL = productRequest.ImageURL,
                Name = productRequest.Name,
                Price = productRequest.Price,
                Rating = productRequest.Rating
            };
            productRepository.Create(product);
            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            return productRepository.Search(name).AsEnumerable();
        }

        public bool IsProductExist(int id)
        {
            return productRepository.IsExists(id);
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
        }
    }
}

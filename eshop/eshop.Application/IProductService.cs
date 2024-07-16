using eshop.Application.DataTransferObjects;
using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsByCategory(string categoryName);
        Product GetProduct(int id);
        int CreateProduct(CreateProductRequest productRequest);
        void UpdateProduct(Product product);
        IEnumerable<Product> SearchProductsByName(string name);

        bool IsProductExist(int id);
        void DeleteProduct(int id);
    }
}

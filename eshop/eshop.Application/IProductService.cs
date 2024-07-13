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
        List<Product> GetProducts();
    }
}

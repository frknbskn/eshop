using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
       
        public IEnumerable<Product> Search(string name);
    }
}

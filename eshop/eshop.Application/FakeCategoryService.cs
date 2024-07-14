using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class FakeCategoryService //: ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category(){Id=1,Name="Kitap"},
                new Category(){Id=2,Name="Müzik"},
                new Category(){Id=3,Name="Bilgisayar"}
            };
        }
    }
}

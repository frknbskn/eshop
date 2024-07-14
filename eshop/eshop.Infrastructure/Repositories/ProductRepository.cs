using eshop.Entities;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EshopDbContext dbContext;

        public ProductRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Products.SingleOrDefault(p => p.Id == id);
            dbContext.Products.Remove(entity);
            dbContext.SaveChanges() ;
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public Product GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Product> GetProductByCategory(string categoryName)
        {
            return dbContext.Products.Include(p => p.Category)
                                             .Where(p => p.Category.Name.Contains(categoryName)).ToList();
        }

        public IEnumerable<Product> Search(string name)
        {
            return dbContext.Products.Where(p => p.Name.Contains(name)); //,StringComparison.OrdinalIgnoreCase
        }

        public void Update(Product entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}

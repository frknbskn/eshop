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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopDbContext dbContext;

        public CategoryRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            dbContext.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            dbContext.Categories.Remove(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.AsEnumerable();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public Category GetById(int id)
        {
            return dbContext.Categories.SingleOrDefault(p => p.Id == id);
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            dbContext.Categories.Update(entity);
        }
    }
}

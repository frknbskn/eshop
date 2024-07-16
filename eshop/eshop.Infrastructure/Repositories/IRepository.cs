using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public interface IRepository<T> where T: class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        void Create(T entity);
        bool IsExists(int id);
    }
}

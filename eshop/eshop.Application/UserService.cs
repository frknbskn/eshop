using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>()
        { new User(){Id=1,FullName="Furkan BAŞKAN",UserName="Furkan",Password="123456",Email="a@b.com",Role="Admin" },
         new User(){Id=1,FullName="Melis BAŞKAN",UserName="Melis",Password="123456",Email="a@b.com",Role="Editor" },
         new User(){Id=1,FullName="Eymen BAŞKAN",UserName="Eymen",Password="123456",Email="a@b.com",Role="Customer" }
        };

        public User ValidateUser(string userName, string password)
        {
            return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}

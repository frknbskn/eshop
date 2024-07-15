using eshop.Entities;

namespace eshop.Application
{
    public interface IUserService
    {
        User ValidateUser(string userName,string password);
    }
}
using eshop.Application;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddNecessariesForApp(this IServiceCollection services, string connectionString)
        {
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));
            return services;
        }
    }
}

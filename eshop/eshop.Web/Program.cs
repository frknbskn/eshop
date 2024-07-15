using eshop.Application;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddSession(opt =>
opt.IdleTimeout = TimeSpan.FromMinutes(20));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                                  .AddCookie(option =>
                                  {
                                      option.LoginPath = "/Users/Login";
                                      option.ReturnUrlParameter = "gidilecekSayfa";
                                      option.AccessDeniedPath = "/Users/AccessDenied";
                                  });

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "category",
    pattern: "{category?}/Sayfa{page}" ,
    defaults: new { controller = "Home", action = "Index", page = 1 });


app.MapControllerRoute(
    name: "paging",
    pattern:"Sayfa{page}",
    defaults: new {controller = "Home", action = "Index",page=1});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

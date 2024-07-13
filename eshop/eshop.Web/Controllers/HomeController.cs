using eshop.Entities;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new() {Id=1,Name="Ürün A",Description="Ürün A Açýklamasý",Price=10,Rating=4.6},
                new() {Id=2,Name="Ürün B",Description="Ürün B Açýklamasý",Price=10,Rating=4.6},
                new() {Id=3,Name="Ürün C",Description="Ürün C Açýklamasý",Price=10,Rating=4.6},
                new() {Id=4,Name="Ürün D",Description="Ürün D Açýklamasý",Price=10,Rating=4.6},
                new() {Id=5,Name="Ürün E",Description="Ürün E Açýklamasý",Price=10,Rating=4.6},
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

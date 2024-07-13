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

        public IActionResult Index(int page=1)
        {
            List<Product> products = new List<Product>()
            {
                new() {Id=1,Name="Ürün A",Description="Ürün A Açýklamasý",Price=10,Rating=4.6},
                new() {Id=2,Name="Ürün B",Description="Ürün B Açýklamasý",Price=10,Rating=4.6},
                new() {Id=3,Name="Ürün C",Description="Ürün C Açýklamasý",Price=10,Rating=4.6},
                new() {Id=4,Name="Ürün D",Description="Ürün D Açýklamasý",Price=10,Rating=4.6},
                new() {Id=5,Name="Ürün E",Description="Ürün E Açýklamasý",Price=10,Rating=4.6},
            };
            var pageSize = 4;
            var total = products.Count();
            var pageCount= (int)Math.Ceiling((decimal)total / pageSize);

            ViewBag.PageCount = pageCount;
            ViewBag.ActivePage = page;

            //var paginatedProducts = products.Skip((page - 1) * pageSize).Take(pageSize);//n tane eleman atla ondan sonra 4 tane al.
            var startPoint = page - 1;
            var endPoint = startPoint + pageSize;
            var alternative = products.Take(startPoint..endPoint);


            return View(alternative);
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

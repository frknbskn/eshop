using eshop.Application;
using eshop.Entities;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int page=1)
        {
            //var productService = new FakeProductService();
            var products = productService.GetProducts();

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

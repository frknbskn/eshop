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
                new() {Id=1,Name="�r�n A",Description="�r�n A A��klamas�",Price=10,Rating=4.6},
                new() {Id=2,Name="�r�n B",Description="�r�n B A��klamas�",Price=10,Rating=4.6},
                new() {Id=3,Name="�r�n C",Description="�r�n C A��klamas�",Price=10,Rating=4.6},
                new() {Id=4,Name="�r�n D",Description="�r�n D A��klamas�",Price=10,Rating=4.6},
                new() {Id=5,Name="�r�n E",Description="�r�n E A��klamas�",Price=10,Rating=4.6},
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

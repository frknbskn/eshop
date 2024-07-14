using eshop.Application;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Web.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCard(int id) {
            var product = productService.GetProduct(id);
            if (product != null)
            {
                return Json(new { message = $"{product.Name} sepete eklendi." });
            }
            return Json(new { message = "ürün bulunamadı." });

        }

    }
}

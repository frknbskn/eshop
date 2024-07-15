using eshop.Application;
using eshop.Web.Extensions;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var shoppinCard = getCollectionFromSession();
            return View(shoppinCard);
        }

        public IActionResult AddToCard(int id)
        {
            var product = productService.GetProduct(id);
            if (product != null)
            {
                ShoppingCardCollection shoppingCardCollection = getCollectionFromSession();
                shoppingCardCollection.Add(new BasketItem() { Product = product, Quantity = 1 });
                saveToSession(shoppingCardCollection);


                return Json(new { message = $"{product.Name} sepete eklendi." });
            }
            return Json(new { message = "ürün bulunamadı." });

        }

        private ShoppingCardCollection getCollectionFromSession()
        {
            //var serialized = HttpContext.Session.GetString("basket");
            //if (string.IsNullOrEmpty(serialized))
            //{
            //    return new ShoppingCardCollection();
            //}
            //return JsonConvert.DeserializeObject<ShoppingCardCollection>(serialized);
            return HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();
        }
        private void saveToSession(ShoppingCardCollection collection)
        {
            //string serialized = JsonConvert.SerializeObject(collection);
            //HttpContext.Session.SetString("basket", serialized);
            HttpContext.Session.SetJson("basket", collection);
        }


    }

}

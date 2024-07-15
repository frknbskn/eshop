using eshop.Application;
using eshop.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.Web.Controllers
{
    public class Products : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public Products(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = getCategoriesForSelect();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(productRequest);
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
        private IEnumerable<SelectListItem> getCategoriesForSelect()
        {
            var categories = categoryService.GetCategories();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
    }
}

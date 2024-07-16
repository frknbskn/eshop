using eshop.Application;
using eshop.Application.DataTransferObjects;
using eshop.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProducts()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            return product == null ? NotFound(new {message ="belirtilen id'de ürün yok."}) : Ok(product);
        }
        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Search(string name)
        {
            var products = productService.SearchProductsByName(name);
            return products == null ? NotFound(new {message = "belirtilen isimde ürün yok."}) : Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastId = productService.CreateProduct(request);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = lastId }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Product product)
        {
            if (productService.IsProductExist(id))
            {
                if (ModelState.IsValid)
                {
                    productService.UpdateProduct(product);
                    return Ok(product);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}" });
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            if (productService.IsProductExist(id))
            {
                productService.DeleteProduct(id);
                return Ok();
            }
            return NotFound();
        }
    }
}

using eshop.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API2.Filters
{
    public class IsExistFilter : IActionFilter
    {
        private readonly IProductService productService;

        public IsExistFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = "id parametresi olmalı" });
            }
            if (context.ActionArguments.TryGetValue("id", out object id)) {
                if (!productService.IsProductExist((int)id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id}'li ürün bulunamadı." });
                }
            }
        }
    }
}

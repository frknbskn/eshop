using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API2.Filters
{
    public class IsExistAttribute : TypeFilterAttribute<IsExistFilter>
    {
    }
}

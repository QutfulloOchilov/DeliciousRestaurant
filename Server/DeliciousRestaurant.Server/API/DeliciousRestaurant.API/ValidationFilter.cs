using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DeliciousRestaurant.API
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return next();
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace InventoryManagementSystem.API.Filters
{
    public class ParameterValidation : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments.ContainsKey("guid"))
            {
                Guid guid = (Guid)context.ActionArguments["guid"];
                if(guid == Guid.Empty) {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException("Value is invalid!");
            }
        }
    }
}

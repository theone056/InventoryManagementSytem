using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.API.Filters.ExceptionFilters
{
    public class HandleExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                Content = context.Exception.Message,
                StatusCode = 500,
            };

            context.ExceptionHandled = true;
        }
    }
}

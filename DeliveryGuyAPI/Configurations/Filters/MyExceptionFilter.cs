using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeliveryGuyAPI.Configurations.Filters;

public class MyExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context) => 
       context.Result = new BadRequestObjectResult("An error occurred while processing your request. Please try again later.");
}

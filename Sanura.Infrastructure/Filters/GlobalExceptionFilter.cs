using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Sanura.Infrastructure
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            logger.LogError(exception.Message);
            var validation = new
            {
                Status = 400,
                Title = "Badrequest",
                Detail = exception.Message,
                Type = string.Format("{0}.{1}.{2}",
                context.ActionDescriptor.GetType().GetProperty("ControllerName").GetValue(context.ActionDescriptor),
                context.ActionDescriptor.GetType().GetProperty("ActionName").GetValue(context.ActionDescriptor),
                context.Exception.Message)
            };
            var json = new
            {
                errors = new[] { validation }
            };
            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;

        }
    }
}
using BusinessLogic.ErrorManagment;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JobsPortalAPI.BusinessLogic.ErrorManagment
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context, IErrorLogger errorLogger)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, errorLogger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IErrorLogger errorLogger)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                
                // customize as you need
                error = new
                {
                    message = "Server Error"//exception.Message ,
                    //exception = exception.GetType().Name
                }
            }));
            //errorLogger.SaveErrorException(exception,context.Request.Path);
        }
    }
}

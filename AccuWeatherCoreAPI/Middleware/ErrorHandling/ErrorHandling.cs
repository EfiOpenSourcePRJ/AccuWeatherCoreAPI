
using BusinessLogic.ErrorManagment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Middleware.ErrorHandling.ErrorHandling;

namespace Middleware.ErrorHandling
{
    public class ErrorHandling
    {
        public class ExceptionHandlingMiddleware
        {
            private readonly RequestDelegate next;

            public ExceptionHandlingMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task Invoke(HttpContext context, IErrorLogger errorLogger)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex, errorLogger);
                }
            }

            private static async Task HandleExceptionAsync(HttpContext context, Exception exception, IErrorLogger errorLogger)
            {
                string errorCode = calculateErrorCode(context.TraceIdentifier);
                string message = string.Format("Oopss... An error on web site occurred; please contact the help desk with the following error code: '{0}'  [{1}]", errorCode, context.TraceIdentifier);

               // Log.Error(exception, message);

                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorLogger.SaveErrorException(exception, context.Request.Path,message);
                await context.Response.WriteAsync(message);
            }

            private static string calculateErrorCode(string traceIdentifier)
            {
                const int ErrorCodeLength = 6;
                const string CodeValues = "BCDFGHJKLMNPQRSTVWXYZ";

                MD5 hasher = MD5.Create();

                StringBuilder sb = new StringBuilder(10);

                byte[] traceBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(traceIdentifier));

                int codeValuesLength = CodeValues.Length;

                for (int i = 0; i < ErrorCodeLength; i++)
                {
                    sb.Append(CodeValues[traceBytes[i] % codeValuesLength]);
                }

                return sb.ToString();
            }
        }

       
    }
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}


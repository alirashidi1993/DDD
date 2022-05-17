using Framework.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Framework.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                var response = context.Response;
                response.ContentType = "application/json";
                var apiException = new APIException();
                if(ex is DomainException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiException.Message = ex.Message;
                }
                else
                {
                    apiException.Message = "خطایی در عملیات رخ داده است. لطفا دوباره امتحان کنید";
                }
                var result = JsonSerializer.Serialize(apiException);
                await response.WriteAsync(result);
            }
        }
    }
}

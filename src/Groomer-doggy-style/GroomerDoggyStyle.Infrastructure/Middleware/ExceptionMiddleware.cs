using GroomerDoggyStyle.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace GroomerDoggyStyle.Infrastructure.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();

            ValidationProblemDetails problemDetails;


            if (exceptionType == typeof(NotFoundException))
            {
                problemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Error", new[] { exception.Message } } })
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Title = "Not Found",
                    Status = (int)HttpStatusCode.NotFound,
                    Instance = context.Request.Path
                };

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                problemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Error", new[] { exception.Message } } })
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = context.Request.Path
                };

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;
            await JsonSerializer.SerializeAsync(context.Response.Body, problemDetails);

        }


    }
}

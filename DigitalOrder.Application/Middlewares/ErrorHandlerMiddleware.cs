using DigitalOrder.Application.Bases;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace DigitalOrder.Application.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<List<string>>() { Succedded = false, Data = new List<string>() };

                response.StatusCode = error switch
                {
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    ValidationException => (int)HttpStatusCode.UnprocessableEntity,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    DbUpdateException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                responseModel.StatusCode = (HttpStatusCode)response.StatusCode;

                switch (error)
                {
                    case UnauthorizedAccessException:
                        responseModel.Message = "Unauthorized access.";
                        break;

                    case ValidationException validationException:
                        responseModel.Message = error.Message;
                        foreach (var failure in validationException.Errors)
                        {
                            responseModel.Data.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
                        }
                        break;

                    case KeyNotFoundException:
                        responseModel.Message = "Resource not found.";
                        break;

                    case DbUpdateException dbUpdateException:
                        responseModel.Message = dbUpdateException.Message;
                        break;

                    default:
                        responseModel.Message = error.Message + (error.InnerException != null ? "\n" + error.InnerException.Message : string.Empty);
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
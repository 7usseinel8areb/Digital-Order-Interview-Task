using System.Net;

namespace DigitalOrder.Application.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }

        public Response<T> Delete<T>(string message = null)
        {
            return new()
            {
                StatusCode = HttpStatusCode.OK,
                Succedded = true,
                Message = message ?? "Deleted Successfully"
            };
        }

        public Response<T> Success<T>(T entity, object meta = null)
        {
            return new()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succedded = true,
                Message = "Success",
                Meta = meta
            };
        }

        public Response<T> UnAuthorized<T>()
        {
            return new()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succedded = true,
                Message = "UnAuthorized"
            };
        }

        public Response<T> BadRequest<T>(string message = null)
        {
            return new()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succedded = false,
                Message = message ?? "Bad request"
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succedded = false,
                Message = message ?? "Can't complete this process"
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succedded = false,
                Message = message ?? "Not Found"
            };
        }

        public Response<T> Created<T>(string? message = null, object meta = null)
        {
            return new()
            {
                /*                Data = entity;*/
                Meta = meta,
                Succedded = true,
                StatusCode = HttpStatusCode.Created,
                Message = message ?? "Created"
            };
        }
    }
}

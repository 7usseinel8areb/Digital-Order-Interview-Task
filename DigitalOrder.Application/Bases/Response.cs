using System.Net;

namespace DigitalOrder.Application.Bases
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Succedded = true;
            Data = data;
            Message = message;
        }

        public Response(string message)
        {
            Succedded = false;
            Message = message;
        }
        public Response(string message, bool succedded)
        {
            Succedded = succedded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }

        public object Meta { get; set; }

        public bool Succedded { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public Dictionary<string, List<string>> ErrorsBag { get; set; }

        public T Data { get; set; }
    }
}



using RentGo.Application.Enum;

namespace RentGo.Application.Response
{
    public class Response
    {
        public Response()
        {
        }

        public Response(ResponseStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}

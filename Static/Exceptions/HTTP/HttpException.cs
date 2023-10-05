using System.Net;
using System.Text.RegularExpressions;

namespace Static.Exceptions.HTTP
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public HttpException() {
            StatusCode = (int) HttpStatusCode.InternalServerError;
            Message = HttpException.CodeToMessage(HttpStatusCode.InternalServerError);
        }

        public HttpException(HttpStatusCode code)
        {
            StatusCode = (int)code;
            Message = HttpException.CodeToMessage(code);
        }

        public HttpException(string message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
            Message = message;
        }

        public HttpException(int code, string message)
        {
            StatusCode = code;
            Message = message;
        }

        public HttpException(HttpStatusCode code, string message) {
            StatusCode = (int) code;
            Message = message;
        }

        public static string CodeToMessage (HttpStatusCode code) =>
            Regex.Replace(Enum.GetName(typeof(HttpStatusCode), code)!, "([a-z])([A-Z])", "$1 $2").Trim();
    }
}

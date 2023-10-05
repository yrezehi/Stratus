using System.Net;
using System.Text.RegularExpressions;

namespace Static.Exceptions.HTTP
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public HttpException(int code, string message)
        {
            StatusCode = code;
            Message = message;
        }

        public HttpException() {
            StatusCode = (int) HttpStatusCode.InternalServerError;
            Message = Regex.Replace(Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.InternalServerError)!, "([a-z])([A-Z])", "$1 $2").Trim();
        }

        public HttpException(HttpStatusCode code, string message) {
            StatusCode = (int) code;
            Message = message;
        }

        public HttpException(HttpStatusCode code) {
            StatusCode = (int) code;
            Message = Regex.Replace(Enum.GetName(typeof(HttpStatusCode), code)!, "([a-z])([A-Z])", "$1 $2").Trim();
        }
    }
}

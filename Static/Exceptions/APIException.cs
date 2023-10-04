namespace Static.Exceptions
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public APIException(int code, string message) {
            StatusCode = code;
            Message = message;
        }
    }
}

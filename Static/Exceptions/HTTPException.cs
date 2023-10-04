namespace Static.Exceptions
{
    public class HTTPException : Exception
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public HTTPException(int code, string message) {
            StatusCode = code;
            Message = message;
        }
    }
}

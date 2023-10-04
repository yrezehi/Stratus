using Serilog;
using System.Text.Json;

namespace Static.Exceptions
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate RequestDelegate;

        public GlobalErrorHandler(RequestDelegate requestDelegate) =>
            RequestDelegate = requestDelegate;

        public async Task Invoke(HttpContext context)
        {
            try { await RequestDelegate(context); }
            catch (HTTPException exception) { await HandleException(context, exception); }
            catch (Exception exception) { await HandleException(context, exception); }
        }

        private static async Task HandleException(HttpContext context, Exception exception)
        {
            // Object holds the error details that will be logged in the server
            dynamic loggingErrorObject = new { };

            // To help troubleshoot the issue, trace id will be shown to the user
            string traceId = context.TraceIdentifier.ToString();
            int statusCode = exception is HTTPException ? ((HTTPException) exception).StatusCode : HTTPException.InternalServerError;

            // Show custom error thrown by the developer or Internal Error Message if unhandled error
            string? exceptionMessage = exception is HTTPException ? ((HTTPException)exception).Message : "";


            if (exception is HTTPException)
            {
                loggingErrorObject = new
                {
                    StatusCode = statusCode,
                    Message = ((HTTPException)exception).Message,
                    Cause = "Exception was thrown by the developer's error handling error",
                    TraceId = traceId
                };

                // Convert logging error object to string and log it
                string serializedErrorObject = JsonSerializer.Serialize(loggingErrorObject);
                Log.Error(serializedErrorObject);

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    ErrorMessage = exceptionMessage,
                    TraceId = traceId
                }));
            }
            else
            {
                loggingErrorObject = new
                {
                    StatusCode = statusCode,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    InnerException = exception.InnerException,
                    Cause = "Unhandled exception",
                    TraceId = traceId
                };

                // Convert logging error object to string and log it
                string serializedErrorObject = JsonSerializer.Serialize(loggingErrorObject);
                Log.Error(serializedErrorObject);
                context.Response.Redirect($"/Home/error?message=" + exceptionMessage + "&traceid=" + traceId);
            }

        }
    }
}

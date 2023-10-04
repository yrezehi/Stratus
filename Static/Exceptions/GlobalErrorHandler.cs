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
            dynamic loggingErrorObject = new { };

            string traceId = context.TraceIdentifier.ToString();
            int statusCode = exception is HTTPException ? ((HTTPException) exception).StatusCode : HTTPException.InternalServerError;

            string? exceptionMessage = exception is HTTPException ? ((HTTPException)exception).Message : "";


            if (context.Request.Path.StartsWithSegments("api"))
            {
                loggingErrorObject = new
                {
                    StatusCode = statusCode,
                    Cause = "Exception was thrown by the developer's error handling error",
                    TraceId = traceId
                };

                string serializedErrorObject = JsonSerializer.Serialize(loggingErrorObject);
                Log.Error(serializedErrorObject);

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = exceptionMessage,
                    TraceId = traceId
                }));
            }
            else
            {
                loggingErrorObject = new
                {
                    StatusCode = statusCode,
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

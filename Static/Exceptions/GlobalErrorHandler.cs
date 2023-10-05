using Serilog;
using Static.Exceptions.HTTP;
using System.Net;
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
            catch (HttpException exception) { await HandleException(context, exception); }
            catch (Exception exception) { await HandleException(context, exception); }
        }

        private static async Task HandleException(HttpContext context, Exception exception)
        {
            dynamic loggingErrorObject = new { };

            string traceId = context.TraceIdentifier.ToString();
            int statusCode = exception is HttpException ? ((HttpException) exception).StatusCode : (int) HttpStatusCode.InternalServerError;

            string? exceptionMessage = exception is HttpException ? ((HttpException)exception).Message : HttpException.CodeToMessage(HttpStatusCode.InternalServerError);

            loggingErrorObject = new
            {
                StatusCode = statusCode,
                Cause = "Unhandled exception",
                TraceId = traceId
            };

            string serializedErrorObject = JsonSerializer.Serialize(loggingErrorObject);
            Log.Error(serializedErrorObject);

            if (context.Request.Path.StartsWithSegments("api"))
            {
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
                context.Response.Redirect($"/Home/error?message=" + exceptionMessage + "&traceid=" + traceId);
            }
        }
    }
}

using System.Net.Mime;
using System.Text;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;

namespace UI.HTML
{
    public class HTMLResult : IResult
    {

        private static string DEFAULT_INDEX_PAGE_NAME = "index";

        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = Text.Html;
            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(MapPathToHTML(httpContext.Request.Path));

            throw new NotImplementedException();
        }

        private string MapPathToHTML(string requestPath)
        {
            requestPath = string.IsNullOrEmpty(requestPath) ? DEFAULT_INDEX_PAGE_NAME : requestPath;

            return requestPath;
        }
    }
}

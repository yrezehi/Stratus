using System.IO;
using System.Net.Mime;
using System.Text;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;

namespace UI.HTML
{
    public class HTMLResult : IResult
    {
        private static string DEFAULT_INDEX_PAGE_NAME = "index";
        private static string HTML_FIELS_LOCATION = "HTML\\Files\\";

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
        
        private string LoadHTML(string fileName)
        {
            string filePath = this.BuildHTMLFilePath(fileName);

            if (!Path.Exists(filePath))
                filePath = this.BuildHTMLFilePath(DEFAULT_INDEX_PAGE_NAME);

            return LoadHTMLAsString(filePath);
        }

        private string LoadHTMLAsString(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }

        private string BuildHTMLFilePath(string fileName)
        {
            return Path.Combine(HTML_FIELS_LOCATION, fileName);
        }
    }
}

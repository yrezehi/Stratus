﻿using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace UI.HTML
{
    public class HTMLResult : IResult
    {
        private static string DEFAULT_INDEX_PAGE_NAME = "index";
        private static string HTML_FIELS_LOCATION = "HTML\\Files\\";

        private readonly string FileName;

        public HTMLResult(string fileName) {
            FileName = fileName.Trim();
        }

        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = Text.Html;

            string content = MapPathToHTML(FileName);

            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(content);

            return httpContext.Response.WriteAsync(content);
        }

        private string MapPathToHTML(string requestPath)
        {
            return LoadHTML(string.IsNullOrEmpty(requestPath) ? DEFAULT_INDEX_PAGE_NAME : requestPath);
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
            return Path.Combine(HTML_FIELS_LOCATION, fileName) + ".html";
        }
    }
}

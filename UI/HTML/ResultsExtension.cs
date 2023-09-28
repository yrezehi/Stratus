namespace UI.HTML
{
    public static class ResultsExtension
    {
        public static IResult HTML(this IResultExtensions resultExtensions, string path)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new HTMLResult(path);
        }
    }
}

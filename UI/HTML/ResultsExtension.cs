namespace UI.HTML
{
    public static class ResultsExtension
    {
        public static IResult HTML(this IResultExtensions resultExtensions)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new HTMLResult();
        }
    }
}

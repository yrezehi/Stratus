namespace Static.HTTP.Factory
{
    public class HTTPClientFactory
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public HTTPClientFactory(IHttpClientFactory httpClientFactory) =>
            (HttpClientFactory) = (httpClientFactory);

        public HttpClient Instance() =>
            HttpClientFactory.CreateClient();
    }
}

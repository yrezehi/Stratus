using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.Configuration;

namespace Static.HTTP.Health
{
    public class APICheck : IHealthCheck
    {
        private readonly HttpClient HttpClient;
        private static string EXTERNAL_SERVICES_KEY = "BASE_EXTERNAL_SERVICES";

        public APICheck()
        {
            HttpClient = new HttpClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            IList<string> services = WebConfiguration.GetList<string>(EXTERNAL_SERVICES_KEY);

            IEnumerable<Task<bool>> concurrentResponses = services.Select(IsHeadRequestReachable);

            if (await AnyUnreachableRequest(concurrentResponses))
            {
                return HealthCheckResult.Unhealthy();
            }

            return HealthCheckResult.Healthy();
        }

        private async Task<bool> AnyUnreachableRequest(IEnumerable<Task<bool>> concurrentResponses)
        {
            var responses = await Task.WhenAll(concurrentResponses);

            return responses.ToList().Exists(response => !response);
        }

        private async Task<bool> IsHeadRequestReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return response.IsSuccessStatusCode;
        }
    }
}

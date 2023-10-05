using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Static.Health
{
    public class APICheck : IHealthCheck
    {
        private HttpClient HttpClient;

        public APICheck()
        {
            HttpClient = new HttpClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (await IsHeadRequestReachable(""))
            {
                return HealthCheckResult.Healthy();
            }

            return HealthCheckResult.Unhealthy();
        }

        private async Task<bool> IsHeadRequestReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return response.IsSuccessStatusCode;
        }
    }
}

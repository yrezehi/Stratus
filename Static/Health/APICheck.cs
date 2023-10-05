using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.Configuration;

namespace Static.Health
{
    public class APICheck : IHealthCheck
    {
        private readonly HttpClient HttpClient;

        private static string EXTERNAL_SERVICES = "ExternalServices";

        public APICheck()
        {
            HttpClient = new HttpClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            IList<string> services = WebConfiguration.GetList<string>(EXTERNAL_SERVICES);

            foreach (string service in services)
            {
                if (!(await IsHeadRequestReachable(service)))
                {
                    return HealthCheckResult.Unhealthy();
                }
            }
            
            return HealthCheckResult.Healthy();
        }

        private async Task<bool> IsHeadRequestReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return response.IsSuccessStatusCode;
        }
    }
}

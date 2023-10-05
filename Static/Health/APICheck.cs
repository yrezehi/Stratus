using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Static.Health
{
    public class APICheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> IsReachable()
        {
            throw new NotImplementedException ();
        }
        private async Task<bool> IsHeadRequestReachable()
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.Repositories;

namespace Static.Health
{
    public class DatabaseCheck : IHealthCheck
    {
        private readonly RepositoryContext RepositoryContext;

        public DatabaseCheck(RepositoryContext repositoryContext) =>
            RepositoryContext = repositoryContext;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if(await RepositoryContext.Database.CanConnectAsync())
            {
                return HealthCheckResult.Healthy();
            }

            return HealthCheckResult.Unhealthy();
        }
    }
}

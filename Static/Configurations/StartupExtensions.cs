using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.HTTP.Health;
using Static.Repositories;
using Static.Repositories.Abstracts.Interfaces;

namespace Static.Configurations
{
    public static class StartupExtensions
    {
        public static void RegisterHealthChecks(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks();

            builder.Services.AddSingleton<IHealthCheck, DatabaseCheck>();
            builder.Services.AddSingleton<IHealthCheck, APICheck>();
        }

        public static void RegisterSingletonServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
        }

        public static void RegisterTransientServices(this WebApplicationBuilder builder) { }

        public static void RegisterDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContextPool<RepositoryContext>(option => option.UseInMemoryDatabase("MEMORYDATABASE"));
            builder.Services.AddTransient<IUnitOfWork, IUnitOfWork<RepositoryContext>>();
        }

        public static void RegisterConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Register(builder.Configuration);
        }
    }
}

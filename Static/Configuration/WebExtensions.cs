using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.Health;
using Static.Repositories;
using Static.Repositories.Abstracts.Interfaces;

namespace Static.Configuration
{
    public static class WebExtensions
    {
        public static void RegisterHealthChecks(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks();

            builder.Services.AddSingleton<IHealthCheck, DatabaseCheck>();
            builder.Services.AddSingleton<IHealthCheck, APICheck>();
        }

        public static void RegisterSingletonServices(this WebApplicationBuilder builder) { }

        public static void RegisterTransientServices(this WebApplicationBuilder builder) { }

        public static void RegisterDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<RepositoryContext>(option => option.UseInMemoryDatabase("MEMORYDATABASE"));
            builder.Services.AddTransient<IUnitOfWork, IUnitOfWork<RepositoryContext>>();
        }

        public static void RegisterConfiguration(this WebApplicationBuilder builder)
        {
            WebConfiguration.Register(builder.Configuration);
        }
    }
}

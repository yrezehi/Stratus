using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Static.Health;
using Static.Repositories;
using Static.Repositories.Abstracts.Interfaces;
using Static.Services.Abstracts;

namespace Static.Configuration
{
    public static class WebExtensions
    {
        public static void RegisterSingletonServices(this WebApplicationBuilder builder) {
            builder.Services.AddSingleton<IHealthCheck, DatabaseCheck>();
            builder.Services.AddSingleton<IHealthCheck, APICheck>();
        }

        public static void RegisterTransientServices(this WebApplicationBuilder builder) {
            builder.Services.AddTransient(typeof(ServiceBase<>), typeof(ServiceBase<>));
        }

        public static void RegisterDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<RepositoryContext>(option => option.UseInMemoryDatabase("MEMORYDATABASE"));

            builder.Services.AddTransient<IUnitOfWork, IUnitOfWork<RepositoryContext>>();
        }
    }
}

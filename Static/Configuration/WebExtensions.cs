using Static.Repositories;
using Static.Repositories.Abstracts.Interfaces;
using Static.Services.Abstracts;

namespace Static.Configuration
{
    public static class WebExtensions
    {
        public static void RegisterSingletonServices(this WebApplicationBuilder builder) { }

        public static void RegisterTransientServices(this WebApplicationBuilder builder) {
            builder.Services.AddTransient(typeof(ServiceBase<>), typeof(ServiceBase<>));
        }

        public static void RegisterDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<RepositoryContext>(option => option.UseInMemoryDatabase("OWNERGPT"));

            builder.Services.AddTransient<IUnitOfWork, IUnitOfWork<RepositoryContext>>();
        }
    }
}

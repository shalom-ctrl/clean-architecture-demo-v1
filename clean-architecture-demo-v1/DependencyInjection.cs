using Demo.Application;
using Demo.Infrastructure;
using Demo.Domain;

namespace clean_architecture_demo_v1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddDomainDI(configuration);

            return services;
        }
    }
}

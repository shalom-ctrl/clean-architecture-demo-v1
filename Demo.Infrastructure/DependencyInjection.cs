using Demo.Domain.Interface;
using Demo.Domain.Options;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Repository;
using Demo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

            services.AddHttpClient<ICoinDeskHttpClientService, CoinDeskHttpClientService>();
            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(option =>
            {
                option.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            });


            return services;
        }
    }
}

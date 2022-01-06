using CC.Shared.Injection;
using DataAccess.Organizations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;

namespace Services.Organizations
{
    public class OrganizationInjectModule : IInjectModule
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IOrganizationDataAccess, OrganizationDataAccess>();

            return services;
        }
    }
}

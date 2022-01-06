using System;
using CC.Shared.Injection;
using DataAccess.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services.Documents
{
    public class DocumentInjectionModule : IInjectModule
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentDataAccess, DocumentDataAccess>();

            return services;
        }
    }
}

using System;
using CC.Shared.Injection;
using DataAccess.Documents;
using DataAccess.DocumentVersions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services.DocumentVersions
{
    public class DocumentVersionInjectModule : IInjectModule
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDocumentVersionService, DocumentVersionService>();
            services.AddScoped<IDocumentVersionDataAccess, DocumentVersionDataAccess>();

            return services;
        }
    }
}

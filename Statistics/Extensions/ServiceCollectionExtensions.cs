using CC.Shared.Injection;
using DataAccess.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Statistics.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllInjectModules(this IServiceCollection services)
        {
            var currentAssembly = typeof(IDocumentService).Assembly;
            var assemblies = new List<Assembly> { currentAssembly };
            assemblies.AddRange(currentAssembly.GetInheritedAssemblies());

            var types = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(i => i.IsClassAssignableFrom<IInjectModule>())
                .ToArray();

            foreach (var type in types)
            {
                var module = type.GetUninitializedObject<IInjectModule>();
                module.Register(services, null);
            }
        }

        public static IServiceCollection AddComplyCloudCoreNew(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInjectModules(configuration, typeof(TaskService).Assembly);
            services.RegisterInjectModules(configuration, typeof(TaskDataAccess).Assembly);



            return services;
        }
    }
}

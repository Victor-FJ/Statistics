using DataAccess.Tasks;
using Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Services.Tasks
{
    public class TaskInjectModule : CC.Shared.Injection.IInjectModule
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskDataAccess, TaskDataAccess>();
            return services;
        }
    }
}

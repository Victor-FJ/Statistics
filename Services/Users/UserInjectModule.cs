using CC.Shared.Injection;
using DataAccess.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserInjectModule : IInjectModule
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDataAccess, UserDataAccess>();

            return services;
        }
    }
}

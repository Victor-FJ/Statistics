using CC.Mediator;
using DataAccess.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Statistics.Extensions;
using System.Reflection;
using CC.Log.Contract;
using Microsoft.AspNetCore.Http;
using Services.Tasks.Requests.TotalNumberOfTasks;

namespace Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILog<>),typeof(FakeLog<>));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            Assembly[] assemblies =
            {
                typeof(TotalNumberOfTasksHandler).Assembly,
                typeof(Startup).Assembly,
                typeof(TaskDataAccess).Assembly
            };

            services.AddMediator(Configuration, assemblies);
            services.RegisterAllInjectModules();
            services.AddComplyCloudCoreNew(null);

            services.AddControllers();

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Acipa";
                    document.Info.Description = "Statistics web API";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Victor",
                        Email = "example@exampleMail.dk",
                        Url = "https://example.com/contact"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "ComplyCloud stuff",
                        Url = "https://example.com/license"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}

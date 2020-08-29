using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProfitDistribution.Domain.Mappers;
using ProfitDistribution.Domain.Repositories;
using ProfitDistribution.Domain.Services.Application;
using ProfitDistribution.Domain.Services.Business;

namespace ProfitDistribution
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
            // this method (ConfigureServices) will manage IOC for .NET Core apps.
            // It is a container for all "services" that the app might inject in its classes.
            services.AddControllers();
            // AddSingleton will create only one instance of the dependency, in its first use, always reusing it when needed.
            services.AddSingleton<IDatabaseEmployees, DatabaseEmployees>();
            services.AddSingleton<IDatabaseWeights, DatabaseWeights>();
            services.AddSingleton<IObjectMappers, ObjectMappers>();
            // other ways to add classes for DI are -> AddTransient, AddScoped.
            services.AddTransient<IProfitService, ProfitService>();
            services.AddTransient<IProfitCalculations, ProfitCalculations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStatusCodePages("text/plain", "Error on loading page. Status code: {0}");

        }
    }
}

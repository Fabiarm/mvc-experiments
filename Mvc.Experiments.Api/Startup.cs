using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mvc.Experiments.Api.Extensions;

namespace Mvc.Experiments.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Environment = environment;

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            //_orderServiceConfiguration = Configuration.GetSection(Application.ApplicationName).Get<OrderServiceConfiguration>();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mvc.Experiments.Api.Extensions;
using Mvc.Experiments.Domain.Confiuration;
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Api
{
    public class Startup
    {
        private readonly ConfigSettings configSettings;
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

            configSettings = Configuration.GetSection("App-Configuration").Get<ConfigSettings>();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigSettings>(configSettings);
            services.AddApiVersioningSettings();
            services.AddBusinessServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
          
            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

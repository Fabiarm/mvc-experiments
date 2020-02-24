using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiSwaggerConfiguration(this IApplicationBuilder app, IConfigSettings configSettings)
        {
            if (configSettings.Swagger.EnableSwagger == true)
            {
                string version = "v1";

                if (configSettings.Swagger.EnableAutogenerateFile == true)
                {
                    // Enable middleware to serve generated Swagger as a JSON endpoint.
                    app.UseSwagger();
                }
                else
                {
                    // Disable response cache (optional point)
                    app.UseStaticFiles(new StaticFileOptions()
                    {
                        OnPrepareResponse = context =>
                        {
                            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                            context.Context.Response.Headers.Add("Expires", "-1");
                        }
                    });
                    // Give an access to 'swagger' folder on 'wwwroot'
                    app.UseStaticFiles(new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @$"wwwroot\swagger")),
                        RequestPath = new PathString($"/swagger")
                    });

                    // Enable middleware to serve generated Swagger as a JSON endpoint.
                    app.UseSwagger();
                }

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
                });
            }
            return app;
        }
    }
}

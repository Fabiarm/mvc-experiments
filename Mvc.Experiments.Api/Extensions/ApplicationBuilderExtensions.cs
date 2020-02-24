using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Mvc.Experiments.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Experiments.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiSwaggerConfiguration(this IApplicationBuilder app, IConfigSettings configSettings)
        {
            if (configSettings.Swagger.EnableSwagger == true)
            {
                string version = "v1";
                /*
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @$"wwwroot\swagger")),
                    RequestPath = new PathString($"/swagger")
                });
                */

                if (configSettings.Swagger.EnableAutogenerateFile == true)
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
                    });
                }
                else
                {
                    app.UseSwagger(options =>
                    {
                        options.RouteTemplate = "/swagger/{documentName}/swagger.json";
                        options.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                        {
                            swaggerDoc.Servers = new List<OpenApiServer> {
                            new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/api/{version}" } };
                        });
                    });
                }
            }
            return app;
        }
    }
}

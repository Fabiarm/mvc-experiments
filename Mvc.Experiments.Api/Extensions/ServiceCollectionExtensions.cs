using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Mvc.Experiments.Domain.Interfaces;
using Mvc.Experiments.Domain.Services;

namespace Mvc.Experiments.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            return services;
        }
        public static IServiceCollection AddApiVersioningSettings(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(v =>
            {
                v.ReportApiVersions = true;
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = ApiVersion.Default;
            });
            return services;
        }
    }
}

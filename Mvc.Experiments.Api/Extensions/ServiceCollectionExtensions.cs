using Microsoft.Extensions.DependencyInjection;

namespace Mvc.Experiments.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}

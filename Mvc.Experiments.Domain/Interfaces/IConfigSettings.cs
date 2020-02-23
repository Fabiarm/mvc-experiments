using Mvc.Experiments.Domain.Confiuration;

namespace Mvc.Experiments.Domain.Interfaces
{
    public interface IConfigSettings
    {
        SwaggerSettings Swagger { get; set; }
    }
}

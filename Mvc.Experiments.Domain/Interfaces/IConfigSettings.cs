using Mvc.Experiments.Domain.Confiuration;

namespace Mvc.Experiments.Domain.Interfaces
{
    public interface IConfigSettings
    {
        public SwaggerSettings Swagger { get; set; }
    }
}

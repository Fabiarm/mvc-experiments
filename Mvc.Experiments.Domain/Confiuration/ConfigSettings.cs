
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Domain.Confiuration
{
    public class ConfigSettings: IConfigSettings
    {
       public SwaggerSettings Swagger { get; set; }
    }
}

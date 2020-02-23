using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestApiController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("gettest1")]
        public async Task<string> GetTestMethod1()
        {
            var result = _testService.GetTestMethod1();
            return await Task.FromResult(result);
        }

    }
}
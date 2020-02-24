using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Experiments.Api.Models;
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Api.Controllers
{
    /// <summary>
    /// Summary of the 'TestApi' controller (v1)
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestApiController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Description of the method [1] from Symmary (xml comments) locally
        /// </summary>
        /// <returns>string</returns>
        [HttpPost]
        [Route("gettest1")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<PostTestMethod1Response> GetTestMethod1(PostTestMethod1Request request)
        {
            var result = _testService.GetTestMethod1(request.Param1);
            return await Task.FromResult(
                new PostTestMethod1Response()
                {
                    Result = result
                });
        }

        /// <summary>
        /// Description of the method [2] from Symmary (xml comments) locally
        /// </summary>
        /// <returns>string</returns>
        [HttpPost]
        [Route("gettest2")]
        [ProducesResponseType(200)]
        public async Task<GetTestMethod2Response> GetTestMethod2()
        {
            var result = _testService.GetTestMethod2();
            return await Task.FromResult(
                new GetTestMethod2Response()
                {
                    Result = result
                });
        }

    }
}
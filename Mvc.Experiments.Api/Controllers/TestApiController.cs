using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Api.Controllers
{
    /// <summary>
    /// Summary of the 'TestApi' controller (v1)
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class TestApiController : TestApiControllerBase
    {
        private readonly ITestService _testService;
        public TestApiController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Description of the method [1] from Symmary (xml comments) locally v1
        /// </summary>
        /// <returns>string</returns>
        public async override Task<PostTestMethod1Response> Gettest1([BindRequired, FromBody] PostTestMethod1Request type)
        {
            var result = _testService.GetTestMethod1(type.Param1);
            return await Task.FromResult(
                new PostTestMethod1Response()
                {
                    Result = result
                });
        }

        /// <summary>
        /// Description of the method [2] from Symmary (xml comments) locally v1
        /// </summary>
        /// <returns>string</returns>
        public async override Task<GetTestMethod2Response> Gettest2()
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
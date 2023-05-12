using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestVectorController : ControllerBase
    {
        private readonly ISample ISample;
        private readonly ITestVector ITestVector;

        public TestVectorController(ISample iSample, ITestVector iTestVector)
        {
            ISample = iSample;
            ITestVector = iTestVector;
        }

        /// <summary>
        /// Generates all the TestVectors and returns it for the user
        /// </summary>
        /// <param name="testInputCollection">The list of user input's from which the TestVectors will be generated</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAll(List<TestInputCollection> testInputCollection)
        {
            return Ok(ITestVector.GenerateAll(ISample.GetAll(), testInputCollection));
        }
    }
}

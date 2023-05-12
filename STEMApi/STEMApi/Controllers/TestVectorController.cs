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
        public IActionResult GenerateAll(List<TestInputCollection> testInputCollection)
        {
            return Ok(ITestVector.GenerateAll(ISample.GetAll(), testInputCollection));
        }

        /// <summary>
        /// Remove the unselected TestVectors
        /// </summary>
        /// <param name="ids">List of TestVector Id's to be removed</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemoveUnselected(List<int> ids)
        {
            ITestVector.Remove(ids);
            List<Sample> samples = new List<Sample>();
            foreach (var item in ITestVector.GetAll().GroupBy(x => x.SampleId))
            {
                Sample? sample = ISample.GetById(item.Key);
                if (sample != null) samples.Add(sample);
            }
            return Ok(samples);
        }
    }
}

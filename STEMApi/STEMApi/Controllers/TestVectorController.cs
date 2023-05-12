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
        private readonly IInputCondition IInputCondition;
        private readonly ISample ISample;

        public TestVectorController(IInputCondition iInputCondition, ISample iSample)
        {
            IInputCondition = iInputCondition;
            ISample = iSample;
        }

        [HttpGet]
        public IActionResult GetAll(List<TestInputCollection> testInputCollection)
        {
            //List<TestVector> testVectors = new List<TestVector>();

            //foreach (Sample sample in ISample.GetAll()) {
            //  List<TestInputCollection> filteredCollection = testInputCollection.Where(x => x.SampleIds.Contains(sample.Id)).ToList();
            //  foreach(TestInputCollection coll in filteredCollection)
            //  {
            //    foreach(TestInputCollection coll2 in filteredCollection.Where(x => x.Id != coll.Id))
            //  }
            //}


            //return Ok(testVectors);
            return Ok();
        }
    }
}

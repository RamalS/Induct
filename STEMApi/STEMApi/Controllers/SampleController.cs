using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISample ISample;
        public SampleController(ISample iSample)
        {
            ISample = iSample;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ISample.GetAll());
        }
    }
}

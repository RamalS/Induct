using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestInputController : ControllerBase
    {
        private readonly IInputCondition IInputCondition;
        public TestInputController(IInputCondition iInputCondition)
        {
            IInputCondition = iInputCondition;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(IInputCondition.GetAll());
        }
    }
}

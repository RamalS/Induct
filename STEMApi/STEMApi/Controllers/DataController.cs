using Common;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IInputCondition IInputCondition;
        private readonly ITestVector ITestVector;
        private readonly ISample ISample;
        public DataController(IInputCondition iInputCondition, ITestVector iTestVector, ISample iSample)
        {
            IInputCondition = iInputCondition;
            ITestVector = iTestVector;
            ISample = iSample;
        }

        /// <summary>
        /// Method that parses the data from the json body to some C# classes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            string requestBody = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            JSONInput? jsonInput = JsonSerializer.Deserialize<JSONInput>(requestBody);
            if (jsonInput == null) return BadRequest();
            AppData.JsonInput = jsonInput;
            return Ok(jsonInput);
        }

        /// <summary>
        /// Method that parses the data from the json file to some C# classes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                if (Request.Form.Files.Count == 0) return BadRequest();
                IFormFile? file = Request.Form.Files.FirstOrDefault();
                if (file == null) return BadRequest();
                string requestBody = "";
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    requestBody = await reader.ReadToEndAsync();
                }
                JSONInput? jsonInput = JsonSerializer.Deserialize<JSONInput>(requestBody);
                if (jsonInput == null) return BadRequest();
                AppData.JsonInput = jsonInput;
                List<string> labels = new List<string>() { "Id" };
                labels.AddRange(IInputCondition.GetAll().Select(x => x.Parameter));
                //TestVectorViewModel asd = new()
                //{
                //    Labels = new List<string>() { "Id", "Temperature", "Drainage" },
                //    TestVectors = new List<TestVector>() {
                //        new TestVector{Id = 1, SelectedInput = new List<SelectedInput>()
                //            {
                //                new SelectedInput { InputConditionId = 1, Value = 1},
                //                new SelectedInput { InputConditionId = 2, Value = 8},
                //            }
                //        },
                //        new TestVector{Id = 2, SelectedInput = new List<SelectedInput>()
                //            {
                //                new SelectedInput { InputConditionId = 1, Value = 10},
                //                new SelectedInput { InputConditionId = 2, Value = 7},
                //            }
                //        }
                //    }
                //};
                return Ok(new TestVectorViewModel { Labels = labels, TestVectors = ITestVector.GenerateAll(ISample.GetAll(), jsonInput.TestPointCollections) }); ;
            }
            catch { return BadRequest(); }
        }
    }
}

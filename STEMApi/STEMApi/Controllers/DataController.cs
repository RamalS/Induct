using Common;
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
        public DataController()
        {

        }

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
                List<TestVector> list = new List<TestVector>()
                {
                    new TestVector{Id = 1, SelectedInput = new List<SelectedInput>()
                        {
                            new SelectedInput { InputConditionId = 1, Value = 1},
                            new SelectedInput { InputConditionId = 2, Value = 8},
                        }
                    },
                    new TestVector{Id = 2, SelectedInput = new List<SelectedInput>()
                        {
                            new SelectedInput { InputConditionId = 1, Value = 10},
                            new SelectedInput { InputConditionId = 2, Value = 7},
                        }
                    }
                };
                return Ok(list);
            }
            catch { return BadRequest(); }
        }
    }
}

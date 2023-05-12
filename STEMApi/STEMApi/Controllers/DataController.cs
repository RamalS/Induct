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
                return Ok(jsonInput);
            }
            catch { return BadRequest(); }
        }
    }
}

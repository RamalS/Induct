using Common;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Models;
using Services;
using System.IO;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ICsvService ICsvService;
        private readonly ISample ISample;
        private readonly IWebHostEnvironment IWebHostEnvironment;

        public FileController(ISample iSample, ICsvService iCsvService, IWebHostEnvironment iWebHostEnvironment)
        {
            ISample = iSample;
            ICsvService = iCsvService;
            IWebHostEnvironment = iWebHostEnvironment;
        }

        /// <summary>
        /// Method to export all TestVectors for all samples in a single .csv file
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ExportAll()
        {
            List<string> fileNames = new List<string>();
            string fileName = "export" + DateTime.Now.ToString("ddmmyyyyHHmmss") + ".csv";
            string path = Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", fileName);
            foreach (Sample sample in ISample.GetAll())
            {
                ICsvService.SaveToCsv(path, sample.Name, new List<string> { "Id", "temp", "drain" }, AppData.TestVectors.Where(x => x.SampleId == sample.Id).ToList());
            }
            return Ok("Files" + fileName);
        }

        /// <summary>
        /// Export's all the TestVectors for a single sample
        /// </summary>
        /// <param name="sampleId">The sample's Id to which export the TestVectors</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ExportSingle(int sampleId)
        {
            string fileName = "export" + DateTime.Now.ToString("ddmmyyyyHHmmss") + ".csv";
            ICsvService.SaveToCsv(Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", fileName), "Sample1", new List<string> { "Id", "temp", "drain" }, /*vector*/AppData.TestVectors.Where(x => x.SampleId == sampleId).ToList());
            return Ok("Files/" + fileName);
        }
    }
}

using Common;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Models;
using Services;
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

        [HttpGet]
        public IActionResult Export()
        {
            List<string> fileNames = new List<string>();
            foreach (Sample sample in ISample.GetAll())
            {
                string fileName = Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "test.csv");
                ICsvService.SaveToCsv(fileName, sample.Name, new List<string> { "Id", "temp", "drain" }, AppData.TestVectors.Where(x => x.SampleId == sample.Id).ToList());
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult ExportSingle(int sampleId)
        {
            List<TestVector> vector = new List<TestVector>() {
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

            ICsvService.SaveToCsv(Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "test.csv"), "Sample1", new List<string> { "Id", "temp", "drain" }, vector/*AppData.TestVectors.Where(x => x.SampleId == sampleId).ToList()*/);
            string fileName = ZipFiles(new List<string> { Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "test.csv") });
            return Ok("Files/" + fileName);
        }

        /// <summary>
        /// Zips a list of files
        /// </summary>
        /// <param name="fileNames">The list of files to save to a zip file</param>
        /// <returns>The path of the zip file</returns>
        [NonAction]
        private string ZipFiles(List<string> fileNames)
        {
            string fileName = Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "export" + DateTime.Now.ToString("dd.mm.yyyy-HH:mm:ss") + ".zip");
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create)) { }
            using (FileStream zipToOpen = new FileStream(fileName, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach(string file in fileNames)
                        // Add files to the archive
                        archive.CreateEntry(Path.GetFileName(file));
                }
            }
            return fileName;
        }
    }
}

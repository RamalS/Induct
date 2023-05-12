using Common;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace STEMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ICsvService ICsvService;
        private readonly IWebHostEnvironment IWebHostEnvironment;

        public FileController(ICsvService iCsvService, IWebHostEnvironment iWebHostEnvironment)
        {
            ICsvService = iCsvService;
            IWebHostEnvironment = iWebHostEnvironment;
        }

        [HttpGet]
        public IActionResult Export()
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

            ICsvService.SaveToCsv(Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "test.csv"), "Sample1", new List<string> { "Id", "temp", "drain"}, vector);
            return Ok();
        }

        [HttpGet]
        public IActionResult Export(int sampleId)
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

            ICsvService.SaveToCsv(Path.Combine(IWebHostEnvironment.ContentRootPath, "Files", "test.csv"), "Sample1", new List<string> { "Id", "temp", "drain" }, AppData.TestVectors.Where(x => x.SampleId == sampleId).ToList());
            return Ok();
        }
    }
}

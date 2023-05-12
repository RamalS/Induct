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

        private void generateCombinations(List<List<int>> indices, int index, List<TestInputCollection> filteredCollection, List<int> vectorIndices) {
            if (index == filteredCollection.Count) {
                indices.Add(vectorIndices);
                return;
            }

            for (int i = 0; i < filteredCollection[index].TestPoints.Count; i++) {
                vectorIndices.Add(i);
                generateCombinations(indices, index + 1, filteredCollection, vectorIndices);
                vectorIndices.RemoveAt(vectorIndices.Count - 1);
            }
         }

        [HttpGet]
        public IActionResult GetAll(List<TestInputCollection> testInputCollection)
        {
            List<TestVector> testVectors = new List<TestVector>();
            
            foreach (Sample sample in ISample.GetAll()) {
              // TODO: optimize
                List<TestInputCollection> filteredCollection = testInputCollection.Where(x => x.SampleIds.Contains(sample.Id)).ToList();
                
                List<List<int>> indices = new List<List<int>>();
                generateCombinations(indices, 0, filteredCollection, new List<int>());

                for (int i = 0; i < indices.Count; i++) {
                    TestVector testVector = new TestVector();
                    for (int j = 0; j < indices[i].Count; j++) {
                        SelectedInput selectedInput = new SelectedInput();
                        selectedInput.InputConditionId = filteredCollection[i].InputConditionId;
                        selectedInput.Value = indices[i][j];

                        testVector.SelectedInput.Add(selectedInput);
                    }

                    testVectors.Add(testVector);
                }
            }


            //return Ok(testVectors);
            return Ok();
        }
    }
}

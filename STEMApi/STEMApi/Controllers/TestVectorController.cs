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

        /*
         * Recursively generates combinations of indices for a given collection of test inputs.
         * @param indices The list of combinations of indices.
         * @param index The current index being processed.
         * @param filteredCollection The filtered collection of test inputs.
         * @param vectorIndices The list of indices for the current combination.
         */
        private void generateCombinations(List<List<int>> indices, int index, List<TestInputCollection> filteredCollection, List<int> vectorIndices) {
            // Base cases: 
            // 1. If we generated 1000 test indices do not generate any more.
            // 2. If we have processed all test input collections,
            // add the current combination of indices to the list and return.
            if (indices.Count == 1000) {
                return;
            }
            if (index == filteredCollection.Count) {
                List<int> list = new List<int>();
                list.AddRange(vectorIndices);
                indices.Add(list);
                return;
            }

            for (int i = 0; i < filteredCollection[index].TestPoints.Count; i++) {
                // Add the current index to the list of vector indices.
                vectorIndices.Add(i);

                // Recursively generate combinations for the next test input collection.
                generateCombinations(indices, index + 1, filteredCollection, vectorIndices);

                // Remove the last added index to backtrack and explore other combinations.
                vectorIndices.RemoveAt(vectorIndices.Count - 1);
            }
         }

        [HttpPost]
        public IActionResult GetAll(List<TestInputCollection> testInputCollection)
        {
            List<TestVector> testVectors = new List<TestVector>();

            // Iterate through all samples
            foreach (Sample sample in ISample.GetAll()) {
                // Filter the test input collections based on the sample's ID
                List<TestInputCollection> filteredCollection = testInputCollection.Where(x => x.SampleIds.Contains(sample.Id)).ToList();
                
                // Generate combinations of indices for the filtered test input collections
                List<List<int>> indices = new List<List<int>>();
                List<int> dummy = new List<int>();
                generateCombinations(indices, 0, filteredCollection, dummy);

                // Create test vectors for each combination of indices
                for (int i = 0; i < indices.Count; i++) {
                    TestVector testVector = new TestVector();

                    // Set the sample ID for the test vector
                    testVector.SampleId = sample.Id;

                    // Create selected inputs for the test vector based on the indices
                    for (int j = 0; j < indices[i].Count; j++) {
                        SelectedInput selectedInput = new SelectedInput();

                        // Set the input condition ID for the selected input
                        selectedInput.InputConditionId = filteredCollection[j].InputConditionId;

                         // Set the value for the selected input based on the test point corresponding to the index
                        selectedInput.Value = filteredCollection[j].TestPoints[indices[i][j]].Value;

                        testVector.SelectedInput.Add(selectedInput);
                    }

                    // Add the generated test vector to the list
                    testVectors.Add(testVector);
                }
            }


            return Ok(testVectors);
        }
    }
}

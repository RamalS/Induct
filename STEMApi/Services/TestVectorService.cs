using Common;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TestVectorService : ITestVector
    {
        /// <summary>
        /// Returns the list of TestVectors for the current session
        /// </summary>
        private List<TestVector> getList { get => AppData.TestVectors; }

        /// <summary>
        /// Method to get all the TestVectors
        /// </summary>
        /// <returns>All the generated TestVectors</returns>
        public List<TestVector> GetAll() => getList;

        /// <summary>
        /// Removes the TestVectors with the given Id's in the list
        /// </summary>
        /// <param name="ids">The Id's of the TestVectors to remove</param>
        /// <returns>The remaining items in the list after removing</returns>
        public List<TestVector> Remove(List<int> ids)
        {
            List<TestVector> remove = new List<TestVector>();
            foreach (TestVector testVector in getList) if (ids.Contains(testVector.Id)) remove.Add(testVector);
            foreach (TestVector testVector in remove) getList.Remove(testVector);
            return getList;
        }

        /// <summary>
        /// Generates the best possible TestVectors for the give samples
        /// </summary>
        /// <param name="samples">List of Samples for which to generate the tests</param>
        /// <param name="testInputCollection">List of user's input from which to generate the output</param>
        /// <returns></returns>
        public List<TestVector> GenerateAll(List<Sample> samples, List<TestInputCollection> testInputCollection)
        {
            List<TestVector> testVectors = new List<TestVector>();

            // Iterate through all samples
            foreach (Sample sample in samples)
            {
                // Filter the test input collections based on the sample's ID
                List<TestInputCollection> filteredCollection = testInputCollection.Where(x => x.SampleIds.Contains(sample.Id)).ToList();
                foreach (TestInputCollection testInput in filteredCollection)
                    testInput.TestPoints = testInput.TestPoints.OrderBy(x => x.Value).ToList();
                // Generate combinations of indices for the filtered test input collections
                List<List<int>> indices = new List<List<int>>();
                List<int> dummy = new List<int>();
                GenerateCombinations(indices, 0, filteredCollection, dummy);

                // Create test vectors for each combination of indices
                for (int i = 0; i < indices.Count; i++)
                {
                    TestVector testVector = new TestVector();

                    // Set the sample ID for the test vector
                    testVector.SampleId = sample.Id;

                    // Create selected inputs for the test vector based on the indices
                    for (int j = 0; j < indices[i].Count; j++)
                    {
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
            return testVectors;
        }

        /// <summary>
        /// Recursively generates combinations of indices for a given collection of test inputs.
        /// </summary>
        /// <param name="indices">The list of combinations of indices.</param>
        /// <param name="index">The current index being processed.</param>
        /// <param name="filteredCollection">The filtered collection of test inputs.</param>
        /// <param name="vectorIndices">The list of indices for the current combination.</param>
        private void GenerateCombinations(List<List<int>> indices, int index, List<TestInputCollection> filteredCollection, List<int> vectorIndices)
        {
            // Base cases: 
            // 1. If we generated 150 test indices do not generate any more.
            // 2. If we have processed all test input collections,
            // add the current combination of indices to the list and return.
            if (indices.Count == 150)
            {
                return;
            }
            if (index == filteredCollection.Count)
            {
                List<int> list = new List<int>();
                list.AddRange(vectorIndices);
                indices.Add(list);
                return;
            }

            for (int i = 0; i < filteredCollection[index].TestPoints.Count; i++)
            {
                // Add the current index to the list of vector indices.
                vectorIndices.Add(i);

                // Recursively generate combinations for the next test input collection.
                GenerateCombinations(indices, index + 1, filteredCollection, vectorIndices);

                // Remove the last added index to backtrack and explore other combinations.
                vectorIndices.RemoveAt(vectorIndices.Count - 1);
            }
        }
    }
}

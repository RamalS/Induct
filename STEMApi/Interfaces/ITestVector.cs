using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITestVector
    {
        /// <summary>
        /// Method to get all the TestVectors
        /// </summary>
        /// <returns>All the generated TestVectors</returns>
        List<TestVector> GetAll();
        /// <summary>
        /// Removes the TestVectors with the given Id's in the list
        /// </summary>
        /// <param name="ids">The Id's of the TestVectors to remove</param>
        /// <returns>The remaining items in the list after removing</returns>
        List<TestVector> Remove(List<int> ids);
        List<TestVector> GenerateAll(List<Sample> samples, List<TestInputCollection> testInputCollection)
    }
}

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
    }
}

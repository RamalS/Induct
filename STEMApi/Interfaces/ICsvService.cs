using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICsvService
    {
        /// <summary>
        /// Method for exporting the TestVectors to a .csv file
        /// </summary>
        /// <param name="fileName">The location where to save the file</param>
        /// <param name="sampleName">The sample's name</param>
        /// <param name="labels">The list of labels</param>
        /// <param name="testVectors">The list of TestVectors to export</param>
        void SaveToCsv(string fileName, string sampleName, List<string> labels, List<TestVector> testVectors);
    }
}

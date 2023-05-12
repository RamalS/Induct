using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CsvService : ICsvService
    {
        /// <summary>
        /// Method for exporting the TestVectors to a .csv file
        /// </summary>
        /// <param name="fileName">The location where to save the file</param>
        /// <param name="sampleName">The sample's name</param>
        /// <param name="labels">The list of labels</param>
        /// <param name="testVectors">The list of TestVectors to export</param>
        public void SaveToCsv(string fileName, string sampleName, List<string> labels, List<TestVector> testVectors)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(sampleName);
                writer.WriteLine("Id," + string.Join(",", labels));

                foreach (var testVector in testVectors)
                {
                    writer.WriteLine(testVector.Id + "," + string.Join(",", testVector.SelectedInput.Select(x => x.Value.ToString("0.00")).ToList())); ;
                }
            }
        }
    }
}

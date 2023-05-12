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
        public void SaveToCsv(string fileName, string sampleName, List<string> labels, List<TestVector> testVectors)
        {
            using (var writer = new StreamWriter(fileName))
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

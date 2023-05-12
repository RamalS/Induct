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
        void SaveToCsv(string fileName, string sampleName, List<string> labels, List<TestVector> testVectors);
    }
}

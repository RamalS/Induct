using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestVectorViewModel
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<TestVector> TestVectors { get; set; } = new List<TestVector>();
    }
}

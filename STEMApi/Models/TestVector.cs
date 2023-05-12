using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestVector
    {
        public int Id { get; set; }
        public bool IsUsed { get; set; } = true;
        public int SampleId { get; set; }
        public List<SelectedInput> SelectedInput { get; set; } = new List<SelectedInput>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestInputCollection
    {
        public int Id { get; set; }
        public int InputConditionId { get; set; }
        public List<int> SampleIds { get; set; } = new List<int>();
        public List<TestPoint> TestPoints { get; set; } = new List<TestPoint>();
    }
}

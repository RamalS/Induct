using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InputCondition
    {
        public int Id { get; set; }
        public string Parameter { get; set; } = "";
        public double Min { get; set; }
        public double Typical { get; set; }
        public double Max { get; set; }
        public double TimeBetweenPoints { get; set; }
    }
}

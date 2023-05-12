using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project
    {
        public string Name { get; set; } = "";
        public List<Sample> Samples { get; set; } = new List<Sample>();
        public List<InputCondition> InputConditions { get; set; } = new List<InputCondition>();
    }
}

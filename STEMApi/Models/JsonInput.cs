using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JSONInput
    {
        public Project Project { get; set; } = new Project();
        public List<TestInputCollection> TestPointCollections { get; set; } = new List<TestInputCollection>();
    }
}

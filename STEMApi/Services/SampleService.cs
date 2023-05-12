using Common;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SampleService : ISample
    {
        private List<Sample> getList { get => AppData.JsonInput.Project.Samples; }

        public List<Sample> GetAll() => getList;
    }
}

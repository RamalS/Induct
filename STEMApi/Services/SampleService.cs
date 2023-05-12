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
        /// <summary>
        /// Returns the list of Samples for the current session
        /// </summary>
        private List<Sample> getList { get => AppData.JsonInput.Project.Samples; }

        /// <summary>
        /// Method to get all the samples
        /// </summary>
        /// <returns>Returns all the samples</returns>
        public List<Sample> GetAll() => getList;

        /// <summary>
        /// Method to get a single sample
        /// </summary>
        /// <param name="id">The sample's Id</param>
        /// <returns>The Sample with the given Id, null if not found</returns>
        public Sample? GetById(int id) => getList.SingleOrDefault(x => x.Id == id);
    }
}

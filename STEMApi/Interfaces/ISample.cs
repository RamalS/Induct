using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISample
    {
        /// <summary>
        /// Method to get all the samples
        /// </summary>
        /// <returns>Returns all the samples</returns>
        List<Sample> GetAll();
        /// <summary>
        /// Method to get a single condition
        /// </summary>
        /// <param name="id">The conditions Id</param>
        /// <returns>The Input condition with the given Id, null if not found</returns>
        Sample? GetById(int id);
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInputCondition
    {
        /// <summary>
        /// Method to get all the input conditions
        /// </summary>
        /// <returns>Returns all the input conditions</returns>
        List<InputCondition> GetAll();
        /// <summary>
        /// Method to get a single condition
        /// </summary>
        /// <param name="id">The conditions Id</param>
        /// <returns>The Input condition with the given Id, null if not found</returns>
        InputCondition? GetById(int id);
    }
}

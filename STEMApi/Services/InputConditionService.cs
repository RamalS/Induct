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
    public class InputConditionService : IInputCondition
    {
        /// <summary>
        /// Returns the list of InputConditions for the current session
        /// </summary>
        private List<InputCondition> getList { get => AppData.JsonInput.Project.InputConditions; }

        /// <summary>
        /// Method to get all the input conditions
        /// </summary>
        /// <returns>Returns all the input conditions</returns>
        public List<InputCondition> GetAll() => getList;

        /// <summary>
        /// Method to get a single condition
        /// </summary>
        /// <param name="id">The conditions Id</param>
        /// <returns>The Input condition with the given Id, null if not found</returns>
        public InputCondition? GetById(int id) => getList.SingleOrDefault(x => x.Id == id);
    }
}

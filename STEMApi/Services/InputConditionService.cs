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
        private List<InputCondition> getList { get => AppData.JsonInput.Project.InputConditions; }

        public List<InputCondition> GetAll() => getList;

        public InputCondition? GetById(int id) => getList.SingleOrDefault(x => x.Id == id);
    }
}

﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInputCondition
    {
        List<InputCondition> GetAll();
        InputCondition? GetById(int id);
    }
}

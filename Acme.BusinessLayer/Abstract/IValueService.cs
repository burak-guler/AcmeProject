﻿using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IValueService
    {
        List<Value> GetList();
        void ValueAdd(Value value);
        Value GetByID(int id);
        void ValueDelete(Value value);
        void ValueUpdate(Value value);
    }
}

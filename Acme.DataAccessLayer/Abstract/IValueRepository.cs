﻿using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Acme.DataAccessLayer.Abstract
{
    public interface IValueRepository: IRepository<Value>
    {
        List<Value> GetValueList(int id);
        List<Value> GetOnAllQuestionValue(int id);
    }
}

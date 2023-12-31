﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        int Insert(T P);

        T Get(int id);

        int Delete(List<int> id);

        int Update(T P);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}

﻿using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Abstract
{
    public interface IExamRepository:IRepository<Exam>
    {
        public List<Exam> GetAllUserExam(int id);

    }
}

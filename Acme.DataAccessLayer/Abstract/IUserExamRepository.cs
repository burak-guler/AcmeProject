﻿using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Abstract
{
    public interface IUserExamRepository: IRepository<UserExam>
    {
        int DeleteUserID(int id);
    }
}

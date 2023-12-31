﻿using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        int UserAdd(User user);
        User GetByID(int id);
        int UserDelete(List<int> id);
        int UserUpdate(User user);
        User GetUser(User user);
        
    }
}

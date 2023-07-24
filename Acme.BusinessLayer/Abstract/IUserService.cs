using Acme.Core.Entity;
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
        void UserAdd(User user);
        User GetByID(int id);
        void UserDelete(User user);
        void UserUpdate(User user);
        User GetUser(User user);
    }
}

using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userDal;

        public UserService(IUserRepository userDal)
        {
            _userDal = userDal;
        }

        public User GetByID(int id)
        {
           return _userDal.Get(id);  
        }

        public List<User> GetList()
        {
            return _userDal.List(); 
        }

        public User GetUser(User user)
        {
            return _userDal.LoginList(user);
        }

        public int UserAdd(User user)
        {
          return _userDal.Insert(user);   
        }

        public int UserDelete(int id)
        {
            return _userDal.Delete(id);
        }

        public int UserUpdate(User user)
        {
            return _userDal.Update(user);
        }
    }
}

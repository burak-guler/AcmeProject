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

        public void UserAdd(User user)
        {
           _userDal.Insert(user);   
        }

        public void UserDelete(User user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }
    }
}

using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class UserRepository : IUserDal
    {
        public void Delete(User P)
        {
            throw new NotImplementedException();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(User P)
        {
            throw new NotImplementedException();
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(User P)
        {
            throw new NotImplementedException();
        }
    }
}

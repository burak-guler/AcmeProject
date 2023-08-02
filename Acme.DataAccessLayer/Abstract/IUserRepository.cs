using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Abstract
{
    public interface IUserRepository: IRepository<User>
    {
        public User LoginList(User user);

        
        
    }
}

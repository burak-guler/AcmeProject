using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Acme.Core.Model;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Concrete
{
    public class UserQuestionValueService : IUserQuestionValueService
    {
        private IUserQuestionValueRepository _userQuestionValueDal;

        public UserQuestionValueService(IUserQuestionValueRepository userQuestionValueDal)
        {
            _userQuestionValueDal = userQuestionValueDal;
        }
        public int UserQuestionValueAdd(UserQuestionValue userQuestionValue)
        {
            return _userQuestionValueDal.Insert(userQuestionValue);
        }

        public int UserQuestionValueDelete(List<int> questionID)
        {
           return _userQuestionValueDal.Delete(questionID);
        }

        public int UserQuestionValueUpdate(UserQuestionValue userQuestionValue)
        {
            throw new NotImplementedException();
        }

        public UserQuestionValue GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserQuestionValue> GetList()
        {
            throw new NotImplementedException();
        }

        public int DeleteUserID(int id)
        {
            return _userQuestionValueDal.DeleteUserID(id);
        }
    }
}

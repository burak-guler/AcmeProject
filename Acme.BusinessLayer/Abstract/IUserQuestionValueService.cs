using Acme.Core.Entity;
using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IUserQuestionValueService
    {
        List<UserQuestionValue> GetList();
        int UserQuestionValueAdd(UserQuestionValue userQuestionValue);
        UserQuestionValue GetByID(int id);
        int UserQuestionValueDelete(List<int> questionID);
        int UserQuestionValueUpdate(UserQuestionValue userQuestionValue);
        int DeleteUserID(int id);
    }
}


using Acme.Core.Entity;
using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IUserExamService
    {
        List<UserExam> GetList();
        int UserExamAdd(UserExam userExam);
        Exam GetByID(int id);
        int UserExamDelete(List<int> id);
        int UserExamUpdate(UserExam userExam);
        int DeleteUserID(int id);
    }
}

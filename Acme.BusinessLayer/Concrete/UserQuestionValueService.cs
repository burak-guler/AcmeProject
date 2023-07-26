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
    public class UserQuestionValueService : IUserQuestionValueService
    {
        private IUserQuestionValueRepository _userQuestionValueDal;

        public UserQuestionValueService(IUserQuestionValueRepository userQuestionValueDal)
        {
            _userQuestionValueDal = userQuestionValueDal;
        }
        public int ExamAdd(Exam exam)
        {
            throw new NotImplementedException();
        }

        public int ExamDelete(int id)
        {
           return _userQuestionValueDal.Delete(id);
        }

        public int ExamUpdate(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Exam GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

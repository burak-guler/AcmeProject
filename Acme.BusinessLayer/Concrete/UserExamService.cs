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
    public class UserExamService : IUserExamService
    {
        private IUserExamRepository _userExamRepository;

        public UserExamService(IUserExamRepository userExamRepository)
        {
            _userExamRepository = userExamRepository;
        }

        public Exam GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserExam> GetList()
        {
            throw new NotImplementedException();
        }

        public int UserExamAdd(UserExam userExam)
        {
            throw new NotImplementedException();
        }

        public int UserExamDelete(int id)
        {
            return _userExamRepository.Delete(id);
        }

        public int UserExamUpdate(UserExam userExam)
        {
            throw new NotImplementedException();
        }
    }
}

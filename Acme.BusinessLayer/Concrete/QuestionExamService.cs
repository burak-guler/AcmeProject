using Acme.BusinessLayer.Abstract;
using Acme.Core.Model;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Concrete
{
    public class QuestionExamService : IQuestionExamService
    {
        private IQuestionExamRepository _questionExamRepository;

        public QuestionExamService(IQuestionExamRepository questionExamRepository)
        {
            _questionExamRepository = questionExamRepository;
        }

        public QuestionExam GetByID(int id)
        {
            return _questionExamRepository.Get(id);
        }

        public List<QuestionExam> GetList()
        {
            throw new NotImplementedException();
        }

        public void QuestionExamAdd(QuestionExam questionExam)
        {
            throw new NotImplementedException();
        }

        public void QuestionExamDelete(QuestionExam questionExam)
        {
            throw new NotImplementedException();
        }

        public void QuestionExamUpdate(QuestionExam questionExam)
        {
            throw new NotImplementedException();
        }
    }
}

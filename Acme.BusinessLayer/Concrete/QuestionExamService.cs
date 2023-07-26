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

        public int QuestionExamAdd(QuestionExam questionExam)
        {
           return _questionExamRepository.Insert(questionExam);
        }

        public int QuestionExamDelete(int id)
        {
            return _questionExamRepository.Delete(id);
        }

        public int QuestionExamUpdate(QuestionExam questionExam)
        {
            return _questionExamRepository.Update(questionExam);
        }
    }
}

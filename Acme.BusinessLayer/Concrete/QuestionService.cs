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
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionDal;

        public QuestionService(IQuestionRepository questionDal)
        {
            _questionDal = questionDal;
        }

        public Question GetByID(int id)
        {
            return _questionDal.Get(id);
        }

        public List<Question> GetList()
        {
            return _questionDal.List();
        }

        public List<Question> GetOnAllQuestionExam(int id, int pageSize, int pageNumber, out int totalCount)
        {
            totalCount = 0;
            return _questionDal.GetOnAllQuestionExam(id, pageSize, pageNumber, out totalCount);
        }

        public List<Question> GetQuestion(int id)
        {
            return _questionDal.GetQuestionList(id);
        }

        public int QuestionAdd(Question question)
        {
            return _questionDal.Insert(question);
        }

        public int QuestionDelete(List<int> questionID)
        {
           return _questionDal.Delete(questionID);
        }

        public int QuestionUpdate(Question question)
        {
           return _questionDal.Update(question);
        }
    }
}

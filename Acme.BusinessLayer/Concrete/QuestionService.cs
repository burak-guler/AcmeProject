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

        public List<Question> GetOnAllQuestionExam(int id)
        {
            return _questionDal.GetOnAllQuestionExam(id);
        }

        public List<Question> GetQuestion(int id)
        {
            return _questionDal.GetQuestionList(id);
        }

        public void QuestionAdd(Question question)
        {
             _questionDal.Insert(question);
        }

        public void QuestionDelete(Question question)
        {
            _questionDal.Delete(question);
        }

        public void QuestionUpdate(Question question)
        {
           _questionDal.Update(question);
        }
    }
}

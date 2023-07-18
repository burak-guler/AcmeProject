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
        private IQuestionDal _questionDal;

        public QuestionService(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public Question GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetList()
        {
            throw new NotImplementedException();
        }

        public void QuestionAdd(Question question)
        {
            throw new NotImplementedException();
        }

        public void QuestionDelete(Question question)
        {
            throw new NotImplementedException();
        }

        public void QuestionUpdate(Question question)
        {
            throw new NotImplementedException();
        }
    }
}

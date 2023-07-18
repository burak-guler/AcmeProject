using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class QuestionRepository : IQuestionDal
    {
        public void Delete(Question P)
        {
            throw new NotImplementedException();
        }

        public Question Get(Expression<Func<Question, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Question P)
        {
            throw new NotImplementedException();
        }

        public List<Question> List()
        {
            throw new NotImplementedException();
        }

        public List<Question> List(Expression<Func<Question, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Question P)
        {
            throw new NotImplementedException();
        }
    }
}

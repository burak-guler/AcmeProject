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
    public class ExamRepository : IExamDal
    {
        public void Delete(Exam P)
        {
            throw new NotImplementedException();
        }

        public Exam Get(Expression<Func<Exam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Exam P)
        {
            throw new NotImplementedException();
        }

        public List<Exam> List()
        {
            throw new NotImplementedException();
        }

        public List<Exam> List(Expression<Func<Exam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Exam P)
        {
            throw new NotImplementedException();
        }
    }
}

using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        //private IExamDal ExamDal;

        //public GenericRepository(IExamDal examDal) 
        //{ 
        //    ExamDal = examDal;
        //}

        //public void ConnectDB()
        //{
        //    ExamDal.
        //}

        public void Delete(T P)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(T P)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(T P)
        {
            throw new NotImplementedException();
        }
    }
}

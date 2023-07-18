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
    public class ExamService : IExamService
    {
        private IExamDal _examDal;

        public ExamService(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public void ExamAdd(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void ExamDelete(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void ExamUpdate(Exam exam)
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

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
        private IExamRepository _examDal;

        public ExamService(IExamRepository examDal)
        {
            _examDal = examDal;
        }

        public void ExamAdd(Exam exam)
        {
            _examDal.Insert(exam);  
        }

        public void ExamDelete(Exam exam)
        {
            _examDal.Delete(exam);
        }

        public void ExamUpdate(Exam exam)
        {
            _examDal.Update(exam);
        }

        public Exam GetByID(int id)
        {
            return _examDal.Get(id);
        }

        public List<Exam> GetList()
        {
            return _examDal.List();
        }
    }
}

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

        public int ExamAdd(Exam exam)
        {
           return _examDal.Insert(exam);  
        }

        public int ExamDelete(List<int> id)
        {
           return _examDal.Delete(id);
        }

        public int ExamUpdate(Exam exam)
        {
           return _examDal.Update(exam);
        }

        public List<Exam> GetAllUserExam(int id)
        {
            return _examDal.GetAllUserExam(id);
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

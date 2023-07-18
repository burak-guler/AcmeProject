using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IExamService
    {
        List<Exam> GetList();
        void ExamAdd(Exam exam);
        Exam GetByID(int id);
        void ExamDelete(Exam exam);
        void ExamUpdate(Exam exam);
    }
}

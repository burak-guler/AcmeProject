using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IUserQuestionValueService
    {
        List<Exam> GetList();
        int ExamAdd(Exam exam);
        Exam GetByID(int id);
        int ExamDelete(int id);
        int ExamUpdate(Exam exam);
    }
}


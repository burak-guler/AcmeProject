using Acme.Core.Entity;
using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IQuestionExamService
    {
        List<QuestionExam> GetList();
        void QuestionExamAdd(QuestionExam questionExam);
        QuestionExam GetByID(int id);
        void QuestionExamDelete(QuestionExam questionExam);
        void QuestionExamUpdate(QuestionExam questionExam);
    }
}

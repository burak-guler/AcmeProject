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
        int QuestionExamAdd(QuestionExam questionExam);
        QuestionExam GetByID(int id);
        int QuestionExamDelete(List<int> questionID);
        int QuestionExamUpdate(QuestionExam questionExam);
    }
}

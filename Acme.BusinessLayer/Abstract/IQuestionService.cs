using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetList();
        List<Question> GetQuestion(int id);
        int QuestionAdd(Question question);
        Question GetByID(int id);
        int QuestionDelete(int id);
        int QuestionUpdate(Question question);
        List<Question> GetOnAllQuestionExam(int id);
    }
}

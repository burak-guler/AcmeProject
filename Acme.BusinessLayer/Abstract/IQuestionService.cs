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
        void QuestionAdd(Question question);
        Question GetByID(int id);
        void QuestionDelete(Question question);
        void QuestionUpdate(Question question);
        List<Question> GetOnAllQuestionExam(int id);
    }
}

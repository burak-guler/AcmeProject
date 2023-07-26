using Acme.Core.Entity;
using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IQuestionValueService
    {
        List<QuestionValue> GetList();
        int QuestionValueAdd(QuestionValue questionValue);
        QuestionValue GetByID(int id);
        int QuestionValueDelete(int id);
        int QuestionValueUpdate(QuestionValue questionValue);
        List<QuestionValue> GetQuestionValue(int id);
    }
}

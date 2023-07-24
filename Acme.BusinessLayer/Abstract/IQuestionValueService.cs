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
        void QuestionValueAdd(QuestionValue questionValue);
        QuestionValue GetByID(int id);
        void QuestionValueDelete(QuestionValue questionValue);
        void QuestionValueUpdate(QuestionValue questionValue);
        List<QuestionValue> GetQuestionValue(int id);
    }
}

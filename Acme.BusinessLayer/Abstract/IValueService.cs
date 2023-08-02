using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IValueService
    {
        List<Value> GetList();
        int ValueAdd(Value value);
        Value GetByID(int id);
        int ValueDelete(List<int> questionID );
        int ValueUpdate(Value value);
        List<Value> GetValue(int id);
        List<Value> GetOnAllQuestionExam(int id);
    }
}

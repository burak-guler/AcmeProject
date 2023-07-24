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
    public class ValueService : IValueService
    {
        private IValueRepository _valueDal;

        public ValueService(IValueRepository valueDal)
        {
            _valueDal = valueDal;
        }

        public Value GetByID(int id)
        {
            return _valueDal.Get(id);
        }

        public List<Value> GetList()
        {
            return _valueDal.List();    
        }

        public List<Value> GetOnAllQuestionExam(int id)
        {
           return _valueDal.GetOnAllQuestionValue(id);
        }

        public List<Value> GetValue(int id)
        {
            return _valueDal.GetValueList(id);
        }

        public void ValueAdd(Value value)
        {
            _valueDal.Insert(value);
        }

        public void ValueDelete(Value value)
        {
            _valueDal.Delete(value);
        }

        public void ValueUpdate(Value value)
        {
            _valueDal.Update(value);
        }
    }
}

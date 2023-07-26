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

        public int ValueAdd(Value value)
        {
            return _valueDal.Insert(value);
        }

        public int ValueDelete(int id)
        {
            return _valueDal.Delete(id);
        }

        public int ValueUpdate(Value value)
        {
            return _valueDal.Update(value);
        }
    }
}

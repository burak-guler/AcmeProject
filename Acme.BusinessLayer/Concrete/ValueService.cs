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
        private IValueDal _valueDal;

        public ValueService(IValueDal valueDal)
        {
            _valueDal = valueDal;
        }

        public Value GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Value> GetList()
        {
            throw new NotImplementedException();
        }

        public void ValueAdd(Value value)
        {
            throw new NotImplementedException();
        }

        public void ValueDelete(Value value)
        {
            throw new NotImplementedException();
        }

        public void ValueUpdate(Value value)
        {
            throw new NotImplementedException();
        }
    }
}

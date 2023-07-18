using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class ValueRepository : IValueDal
    {
        public void Delete(Value P)
        {
            throw new NotImplementedException();
        }

        public Value Get(Expression<Func<Value, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Value P)
        {
            throw new NotImplementedException();
        }

        public List<Value> List()
        {
            throw new NotImplementedException();
        }

        public List<Value> List(Expression<Func<Value, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Value P)
        {
            throw new NotImplementedException();
        }
    }
}

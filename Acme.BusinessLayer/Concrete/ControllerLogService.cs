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
    public class ControllerLogService : IControllerLogService
    {
        private IControllerLogRepository _controllerDal;

        public ControllerLogService(IControllerLogRepository controllerDal)
        {
            _controllerDal = controllerDal;
        }

        public int ControllerLogAdd(ControllerLog controllerLog)
        {
            return _controllerDal.Insert(controllerLog);
        }

        public int ControllerLogDelete(List<int> id)
        {
            throw new NotImplementedException();
        }

        public int ControllerLogUpdate(ControllerLog controllerLog)
        {
            throw new NotImplementedException();
        }

        public ControllerLog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ControllerLog> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

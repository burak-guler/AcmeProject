using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IControllerLogService
    {
        List<ControllerLog> GetList();
        int ControllerLogAdd(ControllerLog controllerLog);
        ControllerLog GetByID(int id);
        int ControllerLogDelete(List<int> id);
        int ControllerLogUpdate(ControllerLog controllerLog);
    }
}

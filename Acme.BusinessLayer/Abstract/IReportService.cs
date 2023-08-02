using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IReportService
    {
        List<Report> GetList();
        int ReportAdd(Report report);
        Report GetByID(int id);
        int ReportDelete(List<int> id);
        int ReportUpdate(Report report);

    }
}

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
    public class ReportService : IReportService
    {
        private IReportRepositroy _reportDal;
        public ReportService(IReportRepositroy reportDal) 
        {
            _reportDal = reportDal;
        }

        public Report GetByID(int id)
        {
           return  _reportDal.Get(id);
        }

        public List<Report> GetList()
        {
            return _reportDal.List();
        }

        public int ReportAdd(Report report)
        {
            return _reportDal.Insert(report);
        }

        public int ReportDelete(List<int> id)
        {
            return _reportDal.Delete(id);
        }

        public int ReportUpdate(Report report)
        {
           return _reportDal.Update(report);
        }
    }
}

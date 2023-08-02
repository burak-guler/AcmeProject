using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepositroy
    {
        public ReportRepository()
        {

        }

        public int Delete(List<int> id)
        {
            throw new NotImplementedException();
        }

        public Report Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Report P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO[dbo].[Report] ([UserID],[ExamID],[Duration],[TrueCount],[WrongCount],[StartDate])VALUES(@UserID, @ExamID, @Duration, @TrueCount, @WrongCount, @StartDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", P.UserID);
            command.Parameters.AddWithValue("@ExamID", P.ExamID);
            command.Parameters.AddWithValue("@Duration", P.Duration);
            command.Parameters.AddWithValue("@TrueCount", P.TrueCount);
            command.Parameters.AddWithValue("@WrongCount", P.WrongCount);
            command.Parameters.AddWithValue("@StartDate", P.StartDate);
            return command.ExecuteNonQuery();
        }

        public List<Report> List()
        {
            throw new NotImplementedException();
        }

        public List<Report> List(Expression<Func<Report, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Report P)
        {
            throw new NotImplementedException();
        }
    }
}

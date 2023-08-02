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
    public class ControllerLogRepository :GenericRepository<ControllerLog>, IControllerLogRepository
    {
        public ControllerLogRepository()
        {

        }

        public int Delete(List<int> id)
        {
            throw new NotImplementedException();
        }

        public ControllerLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ControllerLog P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO[dbo].[ControllerLog] ([ControllerName],[Message],[MessageDate]) VALUES(@ControllerName, @Message, @MessageDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ControllerName", P.ControllerName);
            command.Parameters.AddWithValue("@Message", P.Message);
            command.Parameters.AddWithValue("@MessageDate", P.MessageDate);
            return command.ExecuteNonQuery();
        }

        public List<ControllerLog> List()
        {
            throw new NotImplementedException();
        }

        public List<ControllerLog> List(Expression<Func<ControllerLog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(ControllerLog P)
        {
            throw new NotImplementedException();
        }
    }
}

using Acme.Core.Model;
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
    public class UserQuestionValueRepository : IUserQuestionValueRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public UserQuestionValueRepository()
        {

        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM UserQuestionValue WHERE QuestionValueID = @QuestionValueID;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionValueID", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public UserQuestionValue Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserQuestionValue P)
        {
            throw new NotImplementedException();
        }

        public List<UserQuestionValue> List()
        {
            throw new NotImplementedException();
        }

        public List<UserQuestionValue> List(Expression<Func<UserQuestionValue, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(UserQuestionValue P)
        {
            throw new NotImplementedException();
        }
    }
}

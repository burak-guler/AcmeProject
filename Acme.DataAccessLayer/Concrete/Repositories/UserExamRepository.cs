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
    public class UserExamRepository : IUserExamRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public UserExamRepository()
        {

        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM UserExam WHERE ExamID = @ExamID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExamID", id);

                return command.ExecuteNonQuery();
            }
        }

        public UserExam Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserExam P)
        {
            throw new NotImplementedException();
        }

        public List<UserExam> List()
        {
            throw new NotImplementedException();
        }

        public List<UserExam> List(Expression<Func<UserExam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(UserExam P)
        {
            throw new NotImplementedException();
        }
    }
}

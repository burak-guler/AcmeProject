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
    public class UserExamRepository :GenericRepository<UserExam>, IUserExamRepository
    {
        public UserExamRepository()
        {

        }
        public int Delete(List<int> id)
        {
            var connection = DbConnect();

            string query = "DELETE FROM UserExam WHERE ExamID = @ExamID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ExamID", id[0]);

            return command.ExecuteNonQuery();


        }

        public int DeleteUserID(int id)
        {
            var connection = DbConnect();

            string query = "DELETE FROM UserExam WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", id);

            return command.ExecuteNonQuery();
        }

        public UserExam Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserExam P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO[dbo].[UserExam] ([UserID],[ExamID])VALUES(@UserID, @ExamID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", P.UserID);
            command.Parameters.AddWithValue("@ExamID", P.ExamID);                           
            return command.ExecuteNonQuery();
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

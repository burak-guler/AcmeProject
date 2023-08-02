using Acme.Core.Model;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class UserQuestionValueRepository : GenericRepository<UserQuestionValue>, IUserQuestionValueRepository
    {

        public UserQuestionValueRepository()
        {

        }
        public int Delete(List<int> questionValueID)
        {
            var connection = DbConnect();
            string query = "DELETE FROM UserQuestionValue WHERE QuestionValueID IN (SELECT ID FROM QuestionValue WHERE QuestionID IN (" + string.Join(",", questionValueID) + "))";
            SqlCommand command = new SqlCommand(query, connection);            
         
            return command.ExecuteNonQuery();
        }

        public int DeleteUserID(int id)
        {
            var connection = DbConnect();

            string query = "DELETE FROM UserQuestionValue WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", id);

            return command.ExecuteNonQuery();
        }

        public UserQuestionValue Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserQuestionValue P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO [dbo].[UserQuestionValue] ([UserID],[QuestionValueID])VALUES(@UserID, @QuestionValueID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", P.UserID);
            command.Parameters.AddWithValue("@QuestionValueID", P.QuestionValueID);              
            return command.ExecuteNonQuery();
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

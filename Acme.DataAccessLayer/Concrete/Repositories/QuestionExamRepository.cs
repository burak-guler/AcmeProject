using Acme.Core.Entity;
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
    public class QuestionExamRepository : IQuestionExamRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public QuestionExamRepository()
        {

        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM QuestionExam WHERE ExamID = @ExamID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExamID", id);

                return command.ExecuteNonQuery();
            }
        }

        public QuestionExam Get(int id)
        {
            List<QuestionExam> questionExam = new List<QuestionExam>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[QuestionExam] WHERE ExamID = @ExamID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExamID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int ExamID = Convert.ToInt32(reader["ExamID"]);                   
                    int QuestionID = Convert.ToInt32(reader["QuestionID"]);                   
                    QuestionExam Qex = new QuestionExam();
                    Qex.ID = ID;
                    Qex.ExamID = ExamID;
                    Qex.QuestionID = QuestionID;
                    questionExam.Add(Qex);
                }
            }
            return questionExam.SingleOrDefault();
        }

        public int Insert(QuestionExam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO QuestionExam (QuestionID,ExamID) VALUES (@QuestionID,@ExamID); SELECT CAST(scope_identity() AS int)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@QuestionID", P.QuestionID);
                cmd.Parameters.AddWithValue("@ExamID", P.ExamID);
                connection.Open();
                var result = cmd.ExecuteScalar();
                return (result == null) ? -1 : (int)result;

            }
        }

        public List<QuestionExam> List()
        {
            throw new NotImplementedException();
        }

        public List<QuestionExam> List(Expression<Func<QuestionExam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(QuestionExam P)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class QuestionRepository : IQuestionRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public QuestionRepository()
        {
           
        }

        public void Delete(Question P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Question WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Question Get(int id)
        {
            List<Question> questioN = new List<Question>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[Question] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int Number = Convert.ToInt32(reader["Number"]);
                    int TrueValueID = Convert.ToInt32(reader["TrueValueID"]);
                    string QuestionContent = reader["QuestionContent"].ToString(); 

                    Question Qex = new Question();
                    Qex.ID = ID;
                    Qex.Number = Number;
                    Qex.QuestionContent = QuestionContent;
                    Qex.TrueValueID = TrueValueID;
                    questioN.Add(Qex);
                }
            }
            return questioN.SingleOrDefault();
        }

        public List<Question> GetOnAllQuestionExam(int id)
        {
            List<Question> Que = new List<Question>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT q.ID,q.Number,q.TrueValueID,q.QuestionContent FROM Question q INNER JOIN QuestionExam qe ON q.ID = qe.QuestionID                             WHERE qe.ExamID = @ExamID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExamID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int Number = Convert.ToInt32(reader["Number"]);
                    int TrueValueID = Convert.ToInt32(reader["TrueValueID"]);
                    string QuestionContent = reader["QuestionContent"].ToString();
                    Question Qex = new Question();
                    Qex.ID = ID;
                    Qex.Number = Number;
                    Qex.TrueValueID = TrueValueID;
                    Qex.QuestionContent = QuestionContent;
                    Que.Add(Qex);
                }
            }
            return Que;
        }

        public List<Question> GetQuestionList(int id)
        {
            List<Question> questioN = new List<Question>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[Question] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int Number = Convert.ToInt32(reader["Number"]);
                    int TrueValueID = Convert.ToInt32(reader["TrueValueID"]);
                    string QuestionContent = reader["QuestionContent"].ToString();

                    Question Qex = new Question();
                    Qex.ID = ID;
                    Qex.Number = Number;
                    Qex.QuestionContent = QuestionContent;
                    Qex.TrueValueID = TrueValueID;
                    questioN.Add(Qex);
                }
            }
            return questioN.ToList();
        }

        public void Insert(Question P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Question (Number,QuestionContent,TrueValueID) VALUES (@Number,@QuestionContent,@TrueValueID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", P.Number);
                command.Parameters.AddWithValue("@QuestionContent", P.QuestionContent);
                command.Parameters.AddWithValue("@TrueValueID", P.TrueValueID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Question> List()
        {
            List<Question> question = new List<Question>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "Select * From Question";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int Number = Convert.ToInt32(reader["Number"]);
                    string QuestionContent = reader["QuestionContent"].ToString();

                    Question que = new Question();
                    que.ID = ID;    
                    que.Number = Number;
                    que.QuestionContent = QuestionContent;
                    question.Add(que);  
                }
            }
            return question.ToList();               
        }

        public List<Question> List(Expression<Func<Question, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Question P)
        {
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                string query = "UPDATE Question SET Number = @Number, QuestionContent=@QuestionContent,TrueValueID=@TrueValueID  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@Number", P.Number);
                command.Parameters.AddWithValue("@QuestionContent", P.QuestionContent);
                command.Parameters.AddWithValue("@TrueValueID", P.TrueValueID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

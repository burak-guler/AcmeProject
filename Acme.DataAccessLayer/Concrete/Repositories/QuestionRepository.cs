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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {       

        public QuestionRepository()
        {
           
        }

        public int Delete(List<int> questionID)
        {           
                var connection = DbConnect();
                string deleteQuestionQuery = "DELETE FROM Question WHERE ID IN (" + string.Join(",", questionID) + ")";
                SqlCommand deleteQuestionCommand = new SqlCommand(deleteQuestionQuery, connection);
                return deleteQuestionCommand.ExecuteNonQuery();               
                                          
        }

        public Question Get(int id)
        {
            var connection = DbConnect();
            List<Question> questioN = new List<Question>();
           

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
            
            return questioN.SingleOrDefault();
        }

        public List<Question> GetOnAllQuestionExam(int id, int pageSize, int pageNumber, out int totalCount)
        {
            var connection = DbConnect();
            List<Question> Que = new List<Question>();

            totalCount = 0;
            int offset = (pageNumber - 1) * pageSize;

            string query = "SELECT COUNT(*) OVER() AS TotalCount, q.ID,q.Number,q.TrueValueID,q.QuestionContent FROM Question q INNER JOIN QuestionExam qe ON q.ID = qe.QuestionID WHERE qe.ExamID = @ExamID ORDER BY q.Number ASC OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExamID", id);
                command.Parameters.AddWithValue("@Offset", offset);
                command.Parameters.AddWithValue("@PageSize", pageSize);
            SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int Number = Convert.ToInt32(reader["Number"]);
                    int TrueValueID = Convert.ToInt32(reader["TrueValueID"]);
                    string QuestionContent = reader["QuestionContent"].ToString();
                    totalCount = Convert.ToInt32(reader["TotalCount"]);

                Question Qex = new Question();
                    Qex.ID = ID;
                    Qex.Number = Number;
                    Qex.TrueValueID = TrueValueID;
                    Qex.QuestionContent = QuestionContent;
                    Que.Add(Qex);
                }
            
            return Que;
        }

        public List<Question> GetQuestionList(int id)
        {
            var connection = DbConnect();
            List<Question> questioN = new List<Question>();
            
              

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
            
            return questioN.ToList();
        }

        public int Insert(Question P)
        {
                var connection = DbConnect();
            
                string query = "INSERT INTO Question (Number,QuestionContent,TrueValueID) VALUES (@Number,@QuestionContent,@TrueValueID); SELECT CAST(scope_identity() AS int)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", P.Number);
                command.Parameters.AddWithValue("@QuestionContent", P.QuestionContent);
                command.Parameters.AddWithValue("@TrueValueID", P.TrueValueID);

                var result = command.ExecuteScalar();

                return (result == null) ? -1 : (int)result;
            
        }

        public List<Question> List()
        {
            var connection = DbConnect();
            List<Question> question = new List<Question>();
            
                
                string query = "Select * From Question";
                SqlCommand command = new SqlCommand(query, connection);
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
            
            return question.ToList();               
        }

        public List<Question> List(Expression<Func<Question, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Question P)
        {
            var connection = DbConnect();
            
                string query = "UPDATE Question SET Number = @Number, QuestionContent=@QuestionContent,TrueValueID=@TrueValueID  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@Number", P.Number);
                command.Parameters.AddWithValue("@QuestionContent", P.QuestionContent);
                
                command.Parameters.AddWithValue("@TrueValueID", (P.TrueValueID == null) ? DBNull.Value : P.TrueValueID);
                return command.ExecuteNonQuery();
            
        }
    }
}

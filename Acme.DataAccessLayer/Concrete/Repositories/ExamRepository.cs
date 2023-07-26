using Acme.Core.Entity;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public ExamRepository()
        {
           
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 4. UserQuestionValue tablosundan sınav ile ilişkili QuestionValueID'ye ait verileri silin
                string deleteUserQuestionValueQuery = "DELETE FROM UserQuestionValue WHERE QuestionValueID IN (SELECT ID FROM QuestionValue WHERE QuestionID IN (SELECT QuestionID FROM QuestionExam WHERE ExamID = @ExamID))";
                using (SqlCommand deleteUserQuestionValueCommand = new SqlCommand(deleteUserQuestionValueQuery, connection))
                {
                    deleteUserQuestionValueCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteUserQuestionValueCommand.ExecuteNonQuery();
                }

                
                //6
                string deleteValueQuery = "DELETE FROM Value WHERE ID IN (SELECT ValueID FROM QuestionValue WHERE QuestionID IN (SELECT QuestionID FROM QuestionExam WHERE ExamID = @ExamID))";
                using (SqlCommand deleteValueCommand = new SqlCommand(deleteValueQuery, connection))
                {
                    deleteValueCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteValueCommand.ExecuteNonQuery();
                }

                // 3. QuestionValue tablosundan sınav ile ilişkili sorulara ait şıkları (value değerleri) silin
                string deleteQuestionValueQuery = "DELETE FROM QuestionValue WHERE QuestionID IN (SELECT QuestionID FROM QuestionExam WHERE ExamID = @ExamID)";
                using (SqlCommand deleteQuestionValueCommand = new SqlCommand(deleteQuestionValueQuery, connection))
                {
                    deleteQuestionValueCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteQuestionValueCommand.ExecuteNonQuery();
                }

                ///2
                string deleteUserExamQuery = "DELETE FROM UserExam WHERE ExamID = @ExamID";
                using (SqlCommand deleteUserExamCommand = new SqlCommand(deleteUserExamQuery, connection))
                {
                    deleteUserExamCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteUserExamCommand.ExecuteNonQuery();
                }

                // 5. Question tablosundan sınav ile ilişkili soruları silin
                string deleteQuestionQuery = "DELETE FROM Question WHERE ID IN (SELECT QuestionID FROM QuestionExam WHERE ExamID = @ExamID)";
                using (SqlCommand deleteQuestionCommand = new SqlCommand(deleteQuestionQuery, connection))
                {
                    deleteQuestionCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteQuestionCommand.ExecuteNonQuery();
                }

                // 1. QuestionExam tablosundan sınav ile ilişkili soru verilerini silme
                string deleteQuestionExamQuery = "DELETE FROM QuestionExam WHERE ExamID = @ExamID";
                using (SqlCommand deleteQuestionExamCommand = new SqlCommand(deleteQuestionExamQuery, connection))
                {
                    deleteQuestionExamCommand.Parameters.AddWithValue("@ExamID", id);
                    deleteQuestionExamCommand.ExecuteNonQuery();
                }

                // 7. Exam tablosundan sınavı silin
                string deleteExamQuery = "DELETE FROM Exam WHERE ID = @ExamID";
                using (SqlCommand deleteExamCommand = new SqlCommand(deleteExamQuery, connection))
                {
                    deleteExamCommand.Parameters.AddWithValue("@ExamID", id);
                    return deleteExamCommand.ExecuteNonQuery();
                }
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    string query = "DELETE FROM Exam WHERE ID = @ID";
            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.AddWithValue("@ID", id);
            //    connection.Open();
            //    return command.ExecuteNonQuery();
            //}
        }

        public Exam Get(int id)
        {
            List<Exam> exam = new List<Exam>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[Exam] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Name = reader["Name"].ToString();                     
                    Exam ex = new Exam();
                    ex.ID = ID;
                    ex.Name = Name;
                    exam.Add(ex);
                }
            }
            return exam.SingleOrDefault();
        }

        public int Insert(Exam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Exam (Name) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", P.Name);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public List<Exam> List()
        {
            List<Exam> exam = new List<Exam>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Exam";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Name = reader["Name"].ToString();

                    Exam ex = new Exam();
                    ex.ID = ID;
                    ex.Name = Name;
                    exam.Add(ex);
                }
            }
            return exam.ToList();
        }

        public List<Exam> List(Expression<Func<Exam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Exam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Exam SET Name = @Name  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@Name", P.Name);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}

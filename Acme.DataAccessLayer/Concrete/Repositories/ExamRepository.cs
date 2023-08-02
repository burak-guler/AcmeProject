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
    public class ExamRepository :GenericRepository<Exam> , IExamRepository
    {
        public ExamRepository()
        {
           
        }

        public int  Delete(List<int> id)
        {
            var connection = DbConnect();
            string deleteExamQuery = "DELETE FROM Exam WHERE ID = @ExamID";
            SqlCommand deleteExamCommand = new SqlCommand(deleteExamQuery, connection);
            deleteExamCommand.Parameters.AddWithValue("@ExamID", id[0]);
            return deleteExamCommand.ExecuteNonQuery();


            


        }

        public Exam Get(int id)
        {
            var connection = DbConnect();
            List<Exam> exam = new List<Exam>();
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
            return exam.SingleOrDefault();
        }

        public List<Exam> GetAllUserExam(int id)
        {
            var connection = DbConnect();
            List<Exam> userExam = new List<Exam>();

            string query = "SELECT e.ID,e.Name FROM Exam e INNER JOIN UserExam ue ON e.ID = ue.ExamID WHERE ue.UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ID = Convert.ToInt32(reader["ID"]);
                string name = reader["Name"].ToString();
                Exam exam = new Exam();
                exam.ID = ID;
                exam.Name = name;
                userExam.Add(exam);
            }
            return userExam;
        }

        public int Insert(Exam P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO Exam (Name) VALUES (@Name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", P.Name);
            return command.ExecuteNonQuery();
        }

        public List<Exam> List()
        {
            var connection = DbConnect();
            List<Exam> exam = new List<Exam>();
            string query = "SELECT * FROM Exam";
            SqlCommand command = new SqlCommand(query, connection);
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
            return exam.ToList();

        }

        public List<Exam> List(Expression<Func<Exam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Exam P)
        {
            var connection = DbConnect();
            string query = "UPDATE Exam SET Name = @Name  WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", P.ID);
            command.Parameters.AddWithValue("@Name", P.Name);
            return command.ExecuteNonQuery();


        }
    }
}

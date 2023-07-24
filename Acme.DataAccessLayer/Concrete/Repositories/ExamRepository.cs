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

        public void Delete(Exam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Exam WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
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

        public void Insert(Exam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Exam (Name) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", P.Name);
                connection.Open();
                command.ExecuteNonQuery();
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

        public void Update(Exam P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Exam SET Name = @Name  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@Name", P.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

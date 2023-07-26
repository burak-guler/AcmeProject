using Acme.Core.Entity;
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
    public class ValueRepository : IValueRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public ValueRepository()
        {

        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Exam WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public Value Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Value> GetOnAllQuestionValue(int id)
        {
            List<Value> Val = new List<Value>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Value v INNER JOIN QuestionValue qv ON v.ID = qv.ValueID WHERE qv.QuestionID = @QuestionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Name = reader["Name"].ToString();
                    string QuestionValueContent = reader["QuestionValueContent"].ToString();
                    Value Qex = new Value();
                    Qex.ID = ID;
                    Qex.Name = Name;
                    Qex.QuestionValueContent = QuestionValueContent;
                    Val.Add(Qex);
                }
            }
            return Val;
        }

        public List<Value> GetValueList(int id)
        {
            List<Value> valu = new List<Value>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[Value] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string? Name = reader["Name"].ToString();
                    string? QuestionValueContent = reader["QuestionValueContent"].ToString();

                    Value val = new Value();
                    val.ID = ID;
                    val.Name = Name;
                    val.QuestionValueContent = QuestionValueContent;
                    valu.Add(val);
                }
            }
            return valu;
        }

        public int Insert(Value P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Value (Name,QuestionValueContent) VALUES (@Name,@QuestionValueContent); SELECT CAST(scope_identity() AS int)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@QuestionValueContent", P.QuestionValueContent);
                connection.Open();
                var result = cmd.ExecuteScalar();

                return (result == null) ? -1 : (int)result;

            }
        }

        public List<Value> List()
        {
            List<Value> ValueList = new List<Value>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * From Value";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    char Name = (char)reader["Name"];
                    string QuestionValueContent = reader["QuestionValueContent"].ToString();

                    Value value = new Value();
                   // value.Name = Name;
                    value.QuestionValueContent = QuestionValueContent;
                    ValueList.Add(value);

                }
            }
            return ValueList.ToList();
        }

        public List<Value> List(Expression<Func<Value, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Value P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Value SET Name = @Name,QuestionValueContent=@QuestionValueContent  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@QuestionValueContent", P.QuestionValueContent);
                command.Parameters.AddWithValue("@Name", P.Name);
                connection.Open();
                return command.ExecuteNonQuery();

                
            }
        }
    }
}

    


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
    public class ValueRepository : GenericRepository<Value>,IValueRepository
    {

        public ValueRepository()
        {

        }

        public int Delete(List<int> valueIDs)
        {
            //var connection = DbConnect();
            //string query = "DELETE FROM Value WHERE ID IN (" + string.Join(",", valueIDs) + ")";
            //SqlCommand command = new SqlCommand(query, connection);
            //return command.ExecuteNonQuery();

            using (var connection = DbConnect())
            {
                string query = "DELETE FROM Value WHERE ID IN (" + string.Join(",", valueIDs) + ")";
                SqlCommand command = new SqlCommand(query, connection);
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

                var connection = DbConnect(); 

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
            
            return Val;
        }

        public List<Value> GetValueList(int id)
        {
                var connection = DbConnect();
                List<Value> valu = new List<Value>();          
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
            
            return valu;
        }

        public int Insert(Value P)
        {
            var connection = DbConnect();
            string query = "INSERT INTO Value (Name,QuestionValueContent) VALUES (@Name,@QuestionValueContent); SELECT CAST(scope_identity() AS int)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@QuestionValueContent", P.QuestionValueContent);
                var result = cmd.ExecuteScalar();

                return (result == null) ? -1 : (int)result;

            
        }

        public List<Value> List()
        {
            var connection = DbConnect();
            List<Value> ValueList = new List<Value>();
           
                string query = "Select * From Value";
                SqlCommand command = new SqlCommand(query, connection);
               
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
            
            return ValueList.ToList();
        }

        public List<Value> List(Expression<Func<Value, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(Value P)
        {
                var connection = DbConnect();

                string query = "UPDATE Value SET Name = @Name,QuestionValueContent=@QuestionValueContent  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@QuestionValueContent", P.QuestionValueContent);
                command.Parameters.AddWithValue("@Name", P.Name);                
                return command.ExecuteNonQuery();               
            
        }
    }
}

    


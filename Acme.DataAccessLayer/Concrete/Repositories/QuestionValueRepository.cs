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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class QuestionValueRepository :GenericRepository<QuestionValue> ,IQuestionValueRepository
    {
       

        public QuestionValueRepository()
        {

        }
        public int Delete(List<int> questionID)
        {           
            var connection = DbConnect();

            //string updateQuery = "UPDATE Question SET TrueValueID = NULL WHERE ID IN (" + string.Join(",", questionID) + ")";
            //SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            //updateCommand.ExecuteNonQuery();

            string deleteQuestionValueQuery = "DELETE FROM QuestionValue WHERE QuestionID IN (" + string.Join(",", questionID) + ")";
            SqlCommand command = new SqlCommand(deleteQuestionValueQuery, connection);
           
            return command.ExecuteNonQuery();
        }

        public QuestionValue Get(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionValue GetQuestionValue(int questionID, int valueID)
        {
            var connection = DbConnect();
            List<QuestionValue> questionV = new List<QuestionValue>();



            string query = "SELECT * FROM [dbo].[QuestionValue] WHERE QuestionID = @QuestionID and ValueID= @ValueID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@QuestionID", questionID);
            command.Parameters.AddWithValue("@ValueID", valueID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ID = Convert.ToInt32(reader["ID"]);
                int QuestionID = Convert.ToInt32(reader["QuestionID"]);
                int ValueID = Convert.ToInt32(reader["ValueID"]);

                QuestionValue Qex = new QuestionValue();
                Qex.ID = ID;
                Qex.QuestionID = QuestionID;
                Qex.ValueID = ValueID;

                questionV.Add(Qex);
            }

            return questionV.FirstOrDefault();
        }

        public List<QuestionValue> GetQuestionValueList(int id)
        {
            var connection = DbConnect();
            List<QuestionValue> questionV = new List<QuestionValue>();
            
             

                string query = "SELECT * FROM [dbo].[QuestionValue] WHERE QuestionID = @QuestionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    int QuestionID = Convert.ToInt32(reader["QuestionID"]);
                    int ValueID = Convert.ToInt32(reader["ValueID"]);

                    QuestionValue Qex = new QuestionValue();
                    Qex.ID = ID;
                    Qex.QuestionID = QuestionID;
                    Qex.ValueID = ValueID;

                    questionV.Add(Qex);
                }
            
            return questionV.ToList();
        }

        public int Insert(QuestionValue P)
        {
            var connection = DbConnect();

            string query = "INSERT INTO QuestionValue (QuestionID,ValueID) VALUES (@QuestionID,@ValueID); SELECT CAST(scope_identity() AS int)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionID", P.QuestionID);
            cmd.Parameters.AddWithValue("@ValueID", P.ValueID);
        
            var result = cmd.ExecuteScalar();

            return (result == null) ? -1 : (int)result;



        }

        public List<QuestionValue> List()
        {
            throw new NotImplementedException();
        }

        public List<QuestionValue> List(Expression<Func<QuestionValue, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(QuestionValue P)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class QuestionValueRepository : IQuestionValueRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public QuestionValueRepository()
        {

        }
        public void Delete(QuestionValue P)
        {
            throw new NotImplementedException();
        }

        public QuestionValue Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuestionValue> GetQuestionValueList(int id)
        {
            List<QuestionValue> questionV = new List<QuestionValue>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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
            }
            return questionV.ToList();
        }

        public void Insert(QuestionValue P)
        {
            throw new NotImplementedException();
        }

        public List<QuestionValue> List()
        {
            throw new NotImplementedException();
        }

        public List<QuestionValue> List(Expression<Func<QuestionValue, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionValue P)
        {
            throw new NotImplementedException();
        }
    }
}

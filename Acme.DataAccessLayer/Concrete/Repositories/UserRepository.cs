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
    public class UserRepository : IUserRepository
    {
        private string connectionString = "Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;";

        public UserRepository()
        {
           
        }

        public void Delete(User P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM User WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User P)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
				connection.Open();				
				string query = "INSERT INTO[dbo].[User] ([UserName],[UserSurname],[UserMail],[UserPassword])VALUES(@UserName, @UserSurname, @UserMail, @UserPassword)";				
				SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", P.UserName);
                command.Parameters.AddWithValue("@UserSurname", P.UserSurname);
                command.Parameters.AddWithValue("@UserMail", P.UserMail);
                command.Parameters.AddWithValue("@UserPassword", P.UserPassword);				
				//command.Parameters.AddWithValue("@AdminLogin", P.AdminLogin);                
				command.ExecuteNonQuery();
            }
        }

        public List<User> List()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "Select * From User";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string UserName = reader["UserName"].ToString();
                    string UserSurname = reader["UserSurname"].ToString();
                    string UserPassword = reader["UserPassword"].ToString();
                    string UserMail = reader["UserMail"].ToString();
                    //bool AdminLogin = reader["AdminLogin"].ToString();    

                    User usr = new User();
                    usr.ID = ID;
                    usr.UserName = UserName;
                    usr.UserSurname = UserSurname;
                    usr.UserPassword = UserPassword;
                    usr.UserMail = UserMail;
                    // usr.AdminLogin = AdminLogin;
                    users.Add(usr);
                }
            }
            return users.ToList();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User LoginList(User user)
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [dbo].[User] WHERE UserMail = @UserMail and UserPassword=@UserPassword";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserMail", user.UserMail);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string UserName = reader["UserName"].ToString();
                    string UserSurname = reader["UserSurname"].ToString();
                    string UserPassword = reader["UserPassword"].ToString();
                    string UserMail = reader["UserMail"].ToString();
                    //bool AdminLogin = reader["AdminLogin"].ToString();    

                    User usr = new User();
                    usr.ID = ID;
                    usr.UserName = UserName;
                    usr.UserSurname = UserSurname;
                    usr.UserPassword = UserPassword;
                    usr.UserMail = UserMail;
                    // usr.AdminLogin = AdminLogin;
                    users.Add(usr);
                }
            }
            return users.SingleOrDefault();
        }

        public void Update(User P)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE User SET UserName = @UserName, UserSurname=@UserSurname,UserPassword=@UserPassword,UserMail=@UserMail  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@UserName", P.UserName);
                command.Parameters.AddWithValue("@UserSurname", P.UserSurname);
                command.Parameters.AddWithValue("@UserPassword", P.UserPassword);
                command.Parameters.AddWithValue("@UserMail", P.UserMail);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

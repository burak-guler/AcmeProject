﻿using Acme.Core.Entity;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
     

        public UserRepository()
        {
           
        }

        public int Delete(List<int> id)
        {
                var connection = DbConnect();
                string query = "DELETE FROM [dbo].[User] WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id[0]);
                return command.ExecuteNonQuery();
        }
               

        public User Get(int id)
        {
            var connection = DbConnect();
            List<User> userList = new List<User>();
            string query = "SELECT * FROM [dbo].[User] WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ID = Convert.ToInt32(reader["ID"]);
                string userName = reader["UserName"].ToString();
                string userSurname = reader["UserSurname"].ToString();
                string userMail = reader["UserMail"].ToString();
                string userPassword = reader["UserPassword"].ToString();
                User User = new User();
                User.ID = ID;
                User.UserName = userName;
                User.UserSurname = userSurname;
                User.UserMail = userMail;
                User.UserPassword = userPassword;
                userList.Add(User);
            }
            return userList.SingleOrDefault();
        }

        

        public int Insert(User P)
        {
            var connection = DbConnect();				
				string query = "INSERT INTO[dbo].[User] ([UserName],[UserSurname],[UserMail],[UserPassword])VALUES(@UserName, @UserSurname, @UserMail, @UserPassword)";				
				SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", P.UserName);
                command.Parameters.AddWithValue("@UserSurname", P.UserSurname);
                command.Parameters.AddWithValue("@UserMail", P.UserMail);
                command.Parameters.AddWithValue("@UserPassword", P.UserPassword);				
				//command.Parameters.AddWithValue("@AdminLogin", P.AdminLogin);                
				return command.ExecuteNonQuery();
            
        }

        public List<User> List()
        {
                var connection = DbConnect();

                List<User> users = new List<User>();           

                string query = "Select * From [dbo].[User]";
                SqlCommand command = new SqlCommand(query, connection);
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
            
            return users.ToList();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User LoginList(User user)
        {
                var connection = DbConnect();
                List<User> users = new List<User>();           
             
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
                    bool AdminLogin = (bool)reader["AdminLogin"];    

                    User usr = new User();
                    usr.ID = ID;
                    usr.UserName = UserName;
                    usr.UserSurname = UserSurname;
                    usr.UserPassword = UserPassword;
                    usr.UserMail = UserMail;
                    usr.AdminLogin = AdminLogin;
                    users.Add(usr);
                }
            
            return users.SingleOrDefault();
        }

        public int Update(User P)
        {
                var connection = DbConnect();

                string query = "UPDATE [dbo].[User] SET UserName = @UserName, UserSurname=@UserSurname,UserPassword=@UserPassword,UserMail=@UserMail  WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", P.ID);
                command.Parameters.AddWithValue("@UserName", P.UserName);
                command.Parameters.AddWithValue("@UserSurname", P.UserSurname);
                command.Parameters.AddWithValue("@UserPassword", P.UserPassword);
                command.Parameters.AddWithValue("@UserMail", P.UserMail);
                return command.ExecuteNonQuery();
            
        }

    }
}

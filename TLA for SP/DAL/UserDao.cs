using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DalInterface;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDao : ConnectDB, IUserDao

    {    


        //public UserDao()
        //{
        //    this.users = new List<User>();
        //}

        //public IEnumerable<User> GetAllUsers()
        //{
        //    return this.users.ToList();
        //}

        public string Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", user.userName);
                command.Parameters.AddWithValue("@Login", user.userLogin);
                command.Parameters.AddWithValue("@Password", user.userPassword);
                return command.ExecuteScalar().ToString();


            }
        }

        public void EditUserName(User user, string newName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditUserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", user.userId);
                command.Parameters.AddWithValue("@newName", newName);
                command.ExecuteNonQuery();
            }
        }
        public string EditUserPassword(User user, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditUserPassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", user.userId);
                command.Parameters.AddWithValue("@login", user.userLogin);
                command.Parameters.AddWithValue("@oldPassword", user.userPassword);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                return command.ExecuteScalar().ToString();
            }
        }

        public int UserAuthentication(string login, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UserAuthentication", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                SqlParameter id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                    /*
                    ParameterName = "@id",
                    Value = -1,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                    */
                };
                command.Parameters.Add(id);
                command.ExecuteNonQuery();
                int result = (int)command.Parameters["@id"].Value;
                return result;
                
                
            }

        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    users.Add(new User
                    {
                        userId = (int)reader[0],
                        userName = reader[1].ToString(),
                        userLogin = reader[2].ToString(),
                        userPassword = reader[3].ToString()

                    });
                }
                return users;

            }
        }

         public User GetUserById(int id)
        {
            User user = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUserById", connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User
                    {
                        userId = (int)reader[0],
                        userName = reader[1].ToString(),
                        userLogin = reader[2].ToString(),
                        userPassword = reader[3].ToString()

                    };                  
                }
            }
             return user;
         }

         public User GetUserByLogin(string login)
         {
             User user = new User();
             using (var connection = new SqlConnection(_connectionString))
             {
                 connection.Open();
                 SqlCommand command = new SqlCommand("GetUserByLogin", connection);
                 command.Parameters.AddWithValue("@login", login);
                 command.CommandType = CommandType.StoredProcedure;
                 SqlDataReader reader = command.ExecuteReader();
                 while (reader.Read())
                 {
                     user = new User
                     {
                         userId = (int)reader[0],
                         userName = reader[1].ToString(),
                         userLogin = reader[2].ToString(),
                         userPassword = reader[3].ToString()

                     };


                 }

             }
             return user;

         }



        //public int Add(User value)
        //{
        //    int lastId = 0;
        //    if (users.Any())
        //    {
        //        lastId = users.Max(item => item.Id).Value;
        //    }

        //    value.Id = lastId + 1;

        //    users.Add(value);

        //    return value.Id.Value;
        //}

        //public IEnumerable<User> Delete()
        //{
        //    this.users.Clear();
        //    return this.users.ToList();
        //}
        //public IEnumerable<User> Sort()
        //{
        //    var sortedUsers = from item in users
        //                      orderby item.FirstName
        //                      select item;
        //    return sortedUsers;
        //}
    }
}

using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SEDC.NotesAPI.DataAccess.AdoNetRepository
{
    public class UserAdoNetRepository : IRepository<User>
    {
        private string _connectionString;
        public UserAdoNetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = $@"INSERT INTO Users(Username, FirstName, LastName, Age, Notes)
VALUES(@UsernameText, @FirstNameText, @LastNameText, @AgeText, @NotesText)";
            command.Parameters.AddWithValue("@UsernameText", entity.Username);
            command.Parameters.AddWithValue("@FirstNameText", entity.FirstName);
            command.Parameters.AddWithValue("@LastNameText", entity.LastName);
            command.Parameters.AddWithValue("@AgeText", entity.Age);
            command.Parameters.AddWithValue("@NotesText", entity.Notes);

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = "DELETE FROM Users WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<User> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT * FROM dbo.Users";

            List<User> userDb = new List<User>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userDb.Add(new User 
                { 
                    Id = (int)reader["Id"],
                    Username = (string)reader["Username"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                    Notes = (List<Note>)reader["Notes"]
                });
            }

            sqlConnection.Close();

            return userDb;
        }

        public User GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = $"SELECT * FROM dbo.Users WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            User userDb = new User
                {
                Id = (int)reader["Id"],
                Username = (string)reader["Username"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Age = (int)reader["Age"],
                Notes = (List<Note>)reader["Notes"]
            };

            sqlConnection.Close();

            return userDb;
        }

        public void Update(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = $@"UPDATE dbo.Notes SET Username = @UsernameText, FirstName = @FirstNameText, LastName = @LastNameText, Age = @AgeText, Notes = @NotesText";
            command.Parameters.AddWithValue("@UsernameText", entity.Username);
            command.Parameters.AddWithValue("@FirstNameText", entity.FirstName);
            command.Parameters.AddWithValue("@LastNameText", entity.LastName);
            command.Parameters.AddWithValue("@AgeText", entity.Age);
            command.Parameters.AddWithValue("@NotesText", entity.Notes);

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}

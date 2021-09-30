﻿using Dapper;
using Dapper.Contrib.Extensions;
using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEDC.NotesAPI.DataAccess.DapperRepository
{
    public class UserDapperRepository : IRepository<User>
    {
        private string _connectionString;
        public UserDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert(entity);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = $@"DELETE FROM dbo.Users WHERE Id = @UserID";
                sqlConnection.Execute(query, new { UserId = id });
            }
        }

        public List<User> GetAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                List<User> usersDb = sqlConnection.Query<User>("SELECT * FROM dbo.Users").ToList();
                return usersDb;
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<User>("SELECT * FROM dbo.Users WHERE Id = @UserId", new { UserId = id }).FirstOrDefault();
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Update(entity);
            }
        }
    }
}

﻿using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}

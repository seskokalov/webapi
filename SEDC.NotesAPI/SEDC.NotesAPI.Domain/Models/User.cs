using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace SEDC.NotesAPI.Domain.Models
{
    [Dapper.Contrib.Extensions.Table("Users")]
    public class User
    {        
        public int Id { get; set; } // recognizes Id as key (PK)
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int Age { get; set; }
        public List<Note> Notes { get; set; }
    }
}

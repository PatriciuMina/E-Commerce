using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace E_commerce
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

      
        public User(string name, string email, string phonenumber, string password, string role)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Password = password;
            this.Role = role;
        }

        public User() { }
    }
}
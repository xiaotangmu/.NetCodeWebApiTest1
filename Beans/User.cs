using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Beans
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }

        public User(int id, string username, string pwd)
        {
            Id = id;
            Username = username;
            Pwd = pwd;
        }

        public User()
        {
        }
    }
}

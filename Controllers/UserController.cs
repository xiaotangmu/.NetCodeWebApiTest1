using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Beans;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class UserController : Controller
    {

        public string GetAll(string name)
        {
            return name;
        }

        [HttpPost]
        public User Login(string username, string pwd)
        {

            int i = 1;
            User user = new Beans.User(1, "tan", "123456");
            return user;
        }

        [HttpGet]
        public int Hello(string Name)
        {
            return 1;
        }
    }
}

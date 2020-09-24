using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi1.Beans;
using WebApi1.Config;
using WebApi1.DB;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class UserController : Controller
    {


        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public string GetAll()
        {
            int i = 1;
            string dataBase = DbConnTypeStorage.defaultDbConnString;
            return dataBase;
        }

        [HttpPost]
        public User Login(string username, string pwd)
        {

            int i = 1;


            

            User user = new Beans.User(1, "tan", "123456");

            _userService.getAll();
            return user;
        }

        [HttpGet]
        public int Hello(string Name)
        {
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApi1.Beans;
using WebApi1.Config;
using WebApi1.Dao;
using WebApi1.DB;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserDao userDao;

        private readonly UserService _userService;
        private readonly ILogger _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public List<User> GetAll()
        {
            _logger.LogInformation("#########################");
            int i = 1;
            List<User> list = _userService.getAll();
            return list;
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

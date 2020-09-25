using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Beans;
using WebApi1.Dao;

namespace WebApi1.Services.Impl
{
    public class UserServiceImpl : UserService
    {
        private readonly UserDao _userDao;

        public UserServiceImpl(UserDao userDao = null)
        {
            _userDao = new UserDao();
        }
        public List<User> getAll()
        {
            return _userDao.selectAll();
        }

        public void update()
        {
            int i = 1;
        }
    }
}

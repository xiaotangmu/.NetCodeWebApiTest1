using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Beans;

namespace WebApi1.Services
{
    public interface UserService
    {
        void update();

        List<User> getAll();
    }
}

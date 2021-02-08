using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Project.Models;

namespace Test_Project.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User IsLogin(User model);
    }
}

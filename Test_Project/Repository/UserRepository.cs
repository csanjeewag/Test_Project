using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Test_Project.IRepository;
using Test_Project.Models;

namespace Test_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(IConfiguration configuration)
        {
            _context = new DbContext(configuration);
        }
        public bool Create(User model)
        {
            try
            {
                String sql = $"INSERT INTO Users (Name,Role,Email,Password) " +
                    $"VALUES ('{model.Name}'" +
                    $",'{model.Role}'" +
                    $",'{model.Email}'" +
                    $",'{model.Password}');";
                DataTable datatable = _context.execute(sql);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public User IsLogin(User model)
        {
            try
            {
                String sql = $"SELECT * FROM Users WHERE Email = '{model.Email}' AND Password = '{model.Password}'";
                DataTable datatable = _context.execute(sql);
                List<User> students = _context.ConvertDataTable<User>(datatable);
                return students[0];

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}

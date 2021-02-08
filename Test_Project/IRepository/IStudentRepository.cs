using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Project.Models;

namespace Test_Project.IRepository
{
    public interface IStudentRepository:IBaseRepository<Student>
    {
        public IEnumerable<Student> SearchByName(string search);
    }
}

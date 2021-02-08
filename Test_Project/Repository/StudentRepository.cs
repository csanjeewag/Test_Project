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
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContext _context ;
        public StudentRepository(IConfiguration configuration)
        {
            _context = new DbContext(configuration);
        }
        public bool Create(Student model)
        {
            try
            {
                String sql = $"INSERT INTO Student (Name,Birthday,RegisteredDate,ALStream) " +
                    $"VALUES ('{model.Name}'" +
                    $",'{model.Birthday}'" +
                    $",'{model.RegisteredDate}'" +
                    $",'{model.ALStream}');";
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
            try
            {
                String sql = $"DELETE FROM Student WHERE Id='{Id}';";
                DataTable datatable = _context.execute(sql);
                
                return true;

            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                String sql = $"SELECT * FROM Student";
                DataTable datatable = _context.execute(sql);
                List<Student> students = _context.ConvertDataTable<Student>(datatable);
                return students;

            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }

        public Student GetById(int Id)
        {
            try
            {
                String sql = $"SELECT * FROM Student WHERE Id = '{Id}'";
                DataTable datatable = _context.execute(sql);
                List<Student> students = _context.ConvertDataTable<Student>(datatable);
                return students[0];

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Student> SearchByName(string search)
        {
            
            try
            {
                String sql = $"SELECT* FROM Student WHERE Name LIKE '%{search}%'";
                DataTable datatable = _context.execute(sql);
                List<Student> students = _context.ConvertDataTable<Student>(datatable);
                return students;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(Student model)
        {
            try
            {
                String sql = $"UPDATE Student SET " +
                    $"Name='{model.Name}'" +
                    $",Birthday='{model.Birthday}'" +
                    $",RegisteredDate='{model.RegisteredDate}'" +
                    $",ALStream='{model.ALStream}' " +
                    $"WHERE Id='{model.Id}';";
                DataTable datatable = _context.execute(sql);

                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}

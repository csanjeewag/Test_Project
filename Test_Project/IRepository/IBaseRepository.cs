using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Project.IRepository
{
    public interface IBaseRepository<T>
    {
        public bool Create(T model);
        public bool Update(T model);
        public bool Delete(int Id);
        public T GetById(int Id);
        public IEnumerable<T> GetAll();
    }
}

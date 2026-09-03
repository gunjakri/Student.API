using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IStudentRepo
    {
        public Task<List<Student>> GetAll();
        public Task<Student> GetStudentById(int id);
        public Task<Student> Insert(Student student);
        public Task<Student> Update(int id, Student student);
        public Task<bool> Delete(int id);
    }
}
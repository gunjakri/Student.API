using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    //This is repo class
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Student>> GetAll()
        {
            var result = await _context.Students.ToListAsync();
            return result;
        }
        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return student;
        }

        public async Task<Student> Insert(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(int id, Student student)
        {
            var stu = await _context.Students.FindAsync(id);
            if (stu == null)
            {
                return null;
            }
            stu.Name = student.Name;
            stu.Age = student.Age;
            stu.email = student.email;
            await _context.SaveChangesAsync();
            return student;
        }
    }
}

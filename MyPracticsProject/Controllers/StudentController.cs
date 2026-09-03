using DataLayer.Model;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MyPracticsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepository;
        public StudentController(IStudentRepo repository)
        {
            _studentRepository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _studentRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]// wrong in this endpoint
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return  NotFound("not found");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Student student)
        {
            var result = await _studentRepository.Insert(student);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Student student)
        {
            var result = _studentRepository.Update(id, student);
            return Ok(result);
        }

        [HttpDelete("{id}")] // delete is wrong
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentRepository.Delete(id);
            if (result)
            {
                return Ok("Deleted");
            }
            return NotFound("Student not found");
        }
    }
}

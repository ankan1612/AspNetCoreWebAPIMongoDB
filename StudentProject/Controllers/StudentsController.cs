using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentProject.IRepository;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllAsync()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetAsync(string id)
        {
            var student =  await _studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddAsync([FromBody] Student student)
        { 
            var newStudent = await _studentRepository.Add(student);
            if (newStudent == null)
            {
                return NotFound();
            }
            return newStudent;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateAsync(string id, [FromBody] Student student)
        {
            var updateStudent = await _studentRepository.Update(id, student);
            if (updateStudent == null)
            {
                return NotFound();
            }
            return updateStudent;    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var deleted = await _studentRepository.Remove(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

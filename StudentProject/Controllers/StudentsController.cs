using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Interfaces;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllAsync()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetAsync(string id)
        {
            var student =  await _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddAsync([FromBody] Student student)
        { 
            var newStudent = await _studentService.AddStudent(student);
            if (newStudent == null)
            {
                return NotFound();
            }
            return newStudent;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateAsync(string id, [FromBody] Student student)
        {
            var updateStudent = await _studentService.UpdateStudent(id, student);
            if (updateStudent == null)
            {
                return NotFound();
            }
            return updateStudent;    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var deleted = await _studentService.RemoveStudent(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

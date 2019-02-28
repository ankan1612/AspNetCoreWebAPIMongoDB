using System.Collections.Generic;
using System.Threading.Tasks;
using StudentProject.Models;

namespace StudentProject.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudent(string id);
        Task<Student> AddStudent(Student entity);
        Task<Student> UpdateStudent(string id, Student entity);
        Task<bool> RemoveStudent(string id);
    }
}

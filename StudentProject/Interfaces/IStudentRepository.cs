using System.Collections.Generic;
using System.Threading.Tasks;
using StudentProject.Models;

namespace StudentProject.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetStudent(string id);
        Task<Student> Add(Student student);
        Task<Student> Update(string id, Student student);
        Task<bool> Remove(string id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentProject.Models;

namespace StudentProject.IRepository
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

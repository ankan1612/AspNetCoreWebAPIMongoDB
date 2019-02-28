using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentProject.Interfaces;
using StudentProject.Models;

namespace StudentProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfwork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public async Task<Student> AddStudent(Student student)
        {
            Student addedStudent = null;
            try
            {
                await _unitOfwork.Students.Add(student);

                addedStudent = await _unitOfwork.Students.Get(student.Id);

                return addedStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> GetStudent(string id)
        {
            try
            {
                return await _unitOfwork.Students.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            try
            {
                return await _unitOfwork.Students.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveStudent(string id)
        {
            try
            {
                var actionResult = await _unitOfwork.Students.Remove(id);

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> UpdateStudent(string id, Student student)
        {
            Student updatedStudent = null;
            try
            {
                var actionResult = await _unitOfwork.Students.Update(id, student);

                if(actionResult.IsAcknowledged && actionResult.ModifiedCount > 0)
                {
                    updatedStudent = await _unitOfwork.Students.Get(id);
                }

                return updatedStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

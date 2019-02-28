using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentProject.DBModel;
using StudentProject.Interfaces;
using StudentProject.Models;

namespace StudentProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly MyDbContext _context;

        public StudentRepository(IOptions<Settings> settings)
        {
            _context = new MyDbContext(settings);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                return await _context.Students.Find(s => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> GetStudent(string id)
        {
            var student = Builders<Student>.Filter.Eq("Id", id);

            try
            {
                return await _context.Students.Find(student).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> Add(Student student)
        {
            Student newStudent = null;
            try
            {
                await _context.Students.InsertOneAsync(student);
                var studentId = student.Id;
                if (!string.IsNullOrEmpty(studentId))
                {
                    newStudent = await _context.Students.Find(Builders<Student>.Filter.Eq("Id", studentId)).FirstOrDefaultAsync();
                }
                return newStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> Update(string id, Student student)
        {
            Student updatedStudent = null;
            try
            {
                var oldStudent = await _context.Students.Find(Builders<Student>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
                if (oldStudent != null)
                {
                    student.CreatedOn = oldStudent.CreatedOn;
                    ReplaceOneResult actionResult = await _context.Students.ReplaceOneAsync
                    (
                        n => n.Id.Equals(id), student, new UpdateOptions { IsUpsert = true }
                    );

                    if (actionResult.IsAcknowledged && actionResult.ModifiedCount > 0)
                    {
                        updatedStudent = await _context.Students.Find(Builders<Student>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
                    }
                }

                return updatedStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Students.DeleteOneAsync(Builders<Student>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

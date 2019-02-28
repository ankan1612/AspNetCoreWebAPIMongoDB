using System;
using StudentProject.Models;
using StudentProject.Repository;

namespace StudentProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Student> Students { get; }
    }
}

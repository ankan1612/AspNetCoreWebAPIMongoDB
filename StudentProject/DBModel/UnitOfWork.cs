using Microsoft.Extensions.Options;
using StudentProject.Interfaces;
using StudentProject.Models;
using StudentProject.Repository;

namespace StudentProject.DBModel
{
    public class UnitOfWork : IUnitOfWork
    {
        protected Repository<Student> _students;
        private readonly DbContext _context;

        public UnitOfWork(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public Repository<Student> Students
        {
            get
            {
                if (_students == null)
                {
                    _students = new Repository<Student>(_context._database, "Student");
                }

                return _students;
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}

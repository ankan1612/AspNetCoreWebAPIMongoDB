using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentProject.Models;

namespace StudentProject.DBModel
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(IOptions<Settings> settings) : base(settings)
        {
        }

        public IMongoCollection<Student> Students
        {
            get
            {
                return _database.GetCollection<Student>("Student");
            }
        }
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StudentProject.DBModel
{
    public class DbContext
    {
        public readonly IMongoDatabase _database;

        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
    }
}

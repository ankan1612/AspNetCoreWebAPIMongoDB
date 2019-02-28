using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentProject.Interfaces;

namespace StudentProject.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoCollection<TEntity> _collection;

        public Repository(IMongoDatabase database, string Entity)
        {
            _collection = database.GetCollection<TEntity>(Entity);
        }

        public Task Add(TEntity entity)
        {
            return _collection.InsertOneAsync(entity);
        }

        public Task<TEntity> Get(string id)
        {
            return _collection.Find(Builders<TEntity>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _collection.Find(s => true).ToListAsync();
        }

        public Task<DeleteResult> Remove(string id)
        {
            return _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
        }

        public Task<ReplaceOneResult> Update(string id, TEntity entity)
        {
            return _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity, new UpdateOptions { IsUpsert = true });
        }
    }
}

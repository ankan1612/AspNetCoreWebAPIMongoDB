using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace StudentProject.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(string id);
        Task Add(TEntity entity);
        Task<ReplaceOneResult> Update(string id, TEntity entity);
        Task<DeleteResult> Remove(string id);
    }
}

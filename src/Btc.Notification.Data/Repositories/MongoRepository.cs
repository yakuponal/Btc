using Btc.Notification.Data.Entities.Abstractions;
using Btc.Notification.Data.Repositories.Abstractions;
using MongoDB.Driver;

namespace Btc.Notification.Data.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            collection = database.GetCollection<T>(collectionName);
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await collection.InsertOneAsync(entity);
        }
    }
}

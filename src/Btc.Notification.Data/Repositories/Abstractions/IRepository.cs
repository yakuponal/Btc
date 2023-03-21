using Btc.Notification.Data.Entities.Abstractions;

namespace Btc.Notification.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
    }
}

using BookStore.Api.Models;

namespace BookStore.Api;

public interface IRepostory<T, TId> where T : IEntity<TId>
{
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(TId id);
    Task CreateAsync(T newEntity);
    Task UpdateAsync(TId id, T updatedEntity);
    Task RemoveAsync(TId id);

}

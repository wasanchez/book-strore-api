namespace BookStore.Api.Models;

public abstract class EntityBase<TId> : IEntity<TId>
{  
    public abstract TId? Id { get; set; } 
}

public interface IEntity<T> {
    T? Id {get; set;} 
}

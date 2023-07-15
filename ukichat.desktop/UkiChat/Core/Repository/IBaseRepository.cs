namespace UkiChat.Core.Repository;

public interface IBaseRepository<out TEntity>
{
    TEntity Data { get; }
}
namespace UkiChat.Core.Repository;

public interface IRepositorySync<out TEntity> : IBaseRepository<TEntity>
{
    void Load();
}
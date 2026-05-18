namespace CleanBridge.Access.Domain.Interfaces
{
    public interface IPersistent<TEntity>
    {
        Task SaveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

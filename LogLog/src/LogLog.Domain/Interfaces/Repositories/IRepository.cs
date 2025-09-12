namespace LogLog.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<T?> GetByIdAsync(int id);

        Task<T?> GetByNameAsync(string name);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllByParentIdAsync(int parentId);
    }
}

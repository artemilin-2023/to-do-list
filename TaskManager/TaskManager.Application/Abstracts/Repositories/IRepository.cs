namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> GetAll();
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}

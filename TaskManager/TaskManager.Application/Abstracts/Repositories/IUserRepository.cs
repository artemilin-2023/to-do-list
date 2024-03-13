using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid id);
        IEnumerable<User> GetAll();
        Task AddAsync(User user);
        Task UpdateAsync(Guid id, User User);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}

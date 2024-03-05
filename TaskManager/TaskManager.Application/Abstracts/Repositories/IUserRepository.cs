using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}

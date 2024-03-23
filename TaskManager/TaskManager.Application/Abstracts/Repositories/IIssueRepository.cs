using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IIssueRepository
    {
        Task<Issue?> GetAsync(Guid id);
        Task<IEnumerable<Issue>> GetAllAsync(Guid boardId);
        Task AddAsync(Issue issue);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string? newDescription, IssueStatus? newStatus);
        Task SaveAsync();
    }
}

using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IIssueRepository
    {
        Task<Issue?> GetAsync(Guid id);
        IEnumerable<Issue> GetAll(Guid boardId);
        Task AddAsync(Issue issue);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, Issue issue);
        Task SaveAsync();
    }
}

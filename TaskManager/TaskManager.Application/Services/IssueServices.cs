using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class IssueServices
    {
        private readonly IRepository<Issue> repository;

        public IssueServices(IRepository<Issue> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Issue newIssue)
        {
            var issue = await repository.GetByIdAsync(newIssue.Id);
            if (issue != null)
                throw new Exception($"Issue with id {issue.Id} already exist.");

            await repository.AddAsync(issue);
            await repository.SaveAsync();
        }

        public IEnumerable<Issue> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<Issue> GetAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, Issue newIssue)
        {
            await repository.UpdateAsync(id, newIssue);
            await repository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}

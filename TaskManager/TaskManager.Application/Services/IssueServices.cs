using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class IssueServices
    {
        private readonly IIssueRepository repository;
        private readonly IBoardRepository boardRepository;

        public IssueServices(IIssueRepository repository, IBoardRepository boardRepository)
        {
            this.repository = repository;
            this.boardRepository = boardRepository;
        }

        public async Task CreateAsync(string description, IssueStatus status, Guid boardId)
        {
            var board = await boardRepository.GetAsync(boardId);
            if (board == null)
                throw new Exception($"The Issue could not be created because board with id = {boardId} does not exist");

            var issue = new Issue(
                    Guid.NewGuid(),
                    description,
                    DateTime.UtcNow,
                    boardId,
                    status
                );

            await repository.AddAsync(issue!);
            await repository.SaveAsync();
        }

        public Task<IEnumerable<Issue>> GetAllAsync(Guid boardId)
        {
            return repository.GetAllAsync(boardId);
        }

        public async Task<Issue> GetAsync(Guid id)
        {
            var issue = await repository.GetAsync(id);
            if (issue == null)
                throw new Exception($"Can`t find Issue with id {id}");

            return issue;
        }

        public async Task UpdateAsync(Guid id, string description, IssueStatus status)
        {
            await repository.UpdateAsync(id, description, status);
            await repository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}

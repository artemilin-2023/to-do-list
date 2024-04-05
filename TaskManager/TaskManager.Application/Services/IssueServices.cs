using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class IssueServices
    {
        private readonly IIssueRepository issueRepository;
        private readonly IBoardRepository boardRepository;

        public IssueServices(IIssueRepository issueRepository, IBoardRepository boardRepository)
        {
            this.issueRepository = issueRepository;
            this.boardRepository = boardRepository;
        }

        public async Task CreateAsync(Guid boardId, Guid userId, string description, IssueStatus status)
        {
            if (await HasAccess(userId, boardId) == false)
                throw new Exception("It is imposeble to create issue in someone else's board");

            var issue = new Issue(
                    Guid.NewGuid(),
                    description,
                    DateTime.UtcNow,
                    boardId,
                    status
                );

            await issueRepository.AddAsync(issue!);
            await issueRepository.SaveAsync();
        }

        private async Task<bool> HasAccess(Guid userId, Guid boardId)
        {
            var board = await boardRepository.GetAsync(boardId)
                ?? throw new Exception($"Can't find board with id {boardId}");

            if (board.UserId != userId)
                return false;
            return true;
        }

        public async Task<IEnumerable<Issue>> GetAllAsync(Guid boardId)
        {
            return await issueRepository.GetAllAsync(boardId);
        }

        public async Task<Issue> GetAsync(Guid id)
        {
            var issue = await issueRepository.GetAsync(id);
            if (issue == null)
                throw new Exception($"Can`t find Issue with id {id}");

            return issue;
        }

        public async Task UpdateAsync(Guid id, Guid boardId, Guid userId, string description, IssueStatus status)
        {
            if (await HasAccess(userId, boardId) == false)
                throw new Exception("It is impossible to edit someone else's issue");

            await issueRepository.UpdateAsync(id, description, status);
            await issueRepository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id, Guid boardId, Guid userId)
        {
            if (await HasAccess(userId, boardId) == false)
                throw new Exception("It is impossible to edit someone else's issue");

            await issueRepository.DeleteAsync(id);
            await issueRepository.SaveAsync();
        }
    }
}

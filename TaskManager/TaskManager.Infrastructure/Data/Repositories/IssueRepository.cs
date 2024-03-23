using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly DataContext database;
        private readonly IMapper mapper;

        public IssueRepository(DataContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task AddAsync(Issue issue)
        {
            var issueEntity = mapper.Map<IssueEntity>(issue);
            var board = await database.Boards.SingleAsync(b => b.Id == issue.BoardId);
            issueEntity.Board = board;

            await database.Issues.AddAsync(issueEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var issueEntity = await database.Issues.SingleAsync(i => i.Id == id);
            database.Issues.Remove(issueEntity);
        }

        public async Task<IEnumerable<Issue>> GetAllAsync(Guid boardId)
        {
            var board = await database.Boards.SingleAsync(i => i.Id == boardId);
            return board.Issues.Select(mapper.Map<Issue>).AsEnumerable();
        }

        public async Task<Issue?> GetAsync(Guid id)
        {
            var issueEntity = await database.Issues.SingleOrDefaultAsync(i => i.Id == id);
            return mapper.Map<Issue>(issueEntity);
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string? newDescription, IssueStatus? newStatus)
        {
            var issueEntity = await database.Issues.SingleAsync(i => i.Id == id);
            issueEntity.Description = newDescription ?? issueEntity.Description;
            issueEntity.IssueStatus = newStatus ?? issueEntity.IssueStatus;
        }
    }
}

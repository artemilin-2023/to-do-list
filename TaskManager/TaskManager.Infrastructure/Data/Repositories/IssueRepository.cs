using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class IssueRepository : IRepository<Issue>
    {
        private readonly DataContext database;
        private readonly IMapper mapper;

        public IssueRepository(DataContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task AddAsync(Issue entity)
        {
            var issueEntity = mapper.Map<IssueEntity>(entity);
            await database.Issues.AddAsync(issueEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var issueEntity = await database.Issues.SingleAsync(i => i.Id == id);
            database.Issues.Remove(issueEntity);
        }

        public IEnumerable<Issue> GetAll()
        {
            return database.Issues
                .Select(i => mapper.Map<Issue>(i))
                .AsEnumerable();
        }

        public async Task<Issue> GetByIdAsync(Guid id)
        {
            var issueEntity = await database.Issues.SingleAsync(i => i.Id == id);
            return mapper.Map<Issue>(issueEntity);
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, Issue entity)
        {
            var issueEntity = await database.Issues.SingleAsync(i => i.Id == id);
            issueEntity.Description = entity.Description ?? issueEntity.Description;
            issueEntity.BoardId = entity.BoardId != Guid.Empty ? entity.BoardId : issueEntity.BoardId;
        }
    }
}

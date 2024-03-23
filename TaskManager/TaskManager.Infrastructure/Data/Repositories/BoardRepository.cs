using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DataContext database;
        private readonly IMapper mapper;

        public BoardRepository(DataContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task AddAsync(Board board)
        {
            var entity = mapper.Map<BoardEntity>(board);
            var user = await database.Users.SingleAsync(u => u.Id == board.UserId);
            entity.User = user;

            await database.Boards.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await database.Boards.SingleAsync(x => x.Id == id);
            database.Boards.Remove(entity);
        }

        public IEnumerable<Board> GetAll()
        {
            var boardsEntities = database.Boards.Include(b => b.User).ToList();
            var result = boardsEntities.Select(b => mapper.Map<Board>(b)).AsEnumerable();

            return result;
        }

        public async Task<Board?> GetAsync(Guid id)
        {
            var entity = await database.Boards.SingleOrDefaultAsync(b => b.Id == id);
            return mapper.Map<Board>(entity);
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string newTitle)
        {
            var entity = await database.Boards.SingleAsync(b => b.Id == id);
            entity.Title = newTitle ?? entity.Title;
        }
    }
}

using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Repositories
{
    public interface IBoardRepository
    {
        Task AddAsync(Board board);
        Task<Board?> GetAsync(Guid id);
        IEnumerable<Board> GetAll();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id,  Board newBoard);
        Task SaveAsync();
    }
}

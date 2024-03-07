using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    internal class BoardServises
    {
        private readonly IBoardRepository repository;

        public BoardServises(IBoardRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Board> GetAllAsync()
        {
            return repository.GetAll();
        }

        public async Task<Board> GetAsync(Guid id)
        {
            var board = await repository.GetAsync(id);
            if (board == null)
                throw new Exception($"Can`t find board with id {id}");

            return board;
        }

        public 
    }
}

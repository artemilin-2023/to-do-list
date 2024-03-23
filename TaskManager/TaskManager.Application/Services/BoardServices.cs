using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class BoardServices
    {
        private readonly IBoardRepository boardRepository;
        private readonly IUserRepository userRepository;

        public BoardServices(IBoardRepository boardRepository, IUserRepository userRepository)
        {
            this.boardRepository = boardRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Board> GetAll()
        {
            return boardRepository.GetAll();
        }

        public async Task<Board> GetAsync(Guid id)
        {
            var board = await boardRepository.GetAsync(id);
            if (board == null)
                throw new Exception($"Can`t find board with id {id}");

            return board;
        }

        public async Task CreateAsync(string title, Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception($"Can`t find user with id {userId}");

            var board = new Board(Guid.NewGuid(), title, userId);
            await boardRepository.AddAsync(board);
            await boardRepository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id, Guid userId)
        {
            var board = await boardRepository.GetAsync(id);

            if (board == null)
                throw new Exception($"Can't find board with id {id}");

            if (board.UserId != userId)
                throw new Exception("It is impossible to delete someone else's board");

            await boardRepository.DeleteAsync(id);
            await boardRepository.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, string title)
        {
            await boardRepository.UpdateAsync(id, title);
            await boardRepository.SaveAsync();
        }
    }
}

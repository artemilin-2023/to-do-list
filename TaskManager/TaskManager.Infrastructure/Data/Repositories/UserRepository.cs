using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper mapper;
        private readonly DataContext database;

        public UserRepository(IMapper mapper, DataContext database)
        {
            this.mapper = mapper;
            this.database = database;
        }

        public async Task AddAsync(User user)
        {
            var userEntity = mapper.Map<UserEntity>(user);
            await database.Users.AddAsync(userEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await database.Users
                .SingleAsync(u => u.Id == id);

            database.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            var users = database.Users
                .Include(u => u.Boards)
                .Include(u => u.Comments);

            return users.Select(mapper.Map<User>).AsEnumerable();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var userEntity = await database.Users.SingleOrDefaultAsync(u => u.Email == email);
            return mapper.Map<User>(userEntity);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userEntity = await database.Users.SingleOrDefaultAsync(u => u.Id == id);
            return mapper.Map<User>(userEntity);
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string? newUsername, string? newEmail, string? newPasswordHash)
        {
            var userEntity = await database.Users.FirstAsync(u => u.Id == id);
            userEntity.Email = newEmail ?? userEntity.Email;
            userEntity.Username = newUsername ?? userEntity.Username;
            userEntity.PasswordHash = newPasswordHash ?? userEntity.PasswordHash;
        }
    }
}

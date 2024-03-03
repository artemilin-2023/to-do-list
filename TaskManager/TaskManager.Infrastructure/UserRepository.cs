using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstracts;
using TaskManager.Domain;
using TaskManager.Infrastructure.Entities;

namespace TaskManager.Infrastructure
{
    internal class UserRepository : IRepository<User>
    {
        private readonly Mapper mapper;
        private readonly DataContext database;

        public UserRepository(Mapper mapper, DataContext database)
        {
            ArgumentNullException.ThrowIfNull(mapper);
            ArgumentNullException.ThrowIfNull(database);

            this.mapper = mapper;
            this.database = database;
        }

        public async Task AddAsync(User entity)
        {
            var userEntity = mapper.Map<UserEntity>(entity);
            await database.Users.AddAsync(userEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await database.Users.SingleAsync(u => u.Id == id);
            database.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return database.Users.Select(u => mapper.Map<User>(u)).AsEnumerable();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userEntity = await database.Users.SingleAsync(u => u.Id == id);
            return mapper.Map<User>(userEntity);
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, User entity)
        {
            var user = await database.Users.FirstAsync(u => u.Id == id);
            user.Email = entity.Email ?? user.Email;
            user.Username = entity.Username ?? user.Username;
            user.PasswordHash = entity.PasswordHash ?? user.PasswordHash;
        }
    }
}

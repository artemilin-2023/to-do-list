using TaskManager.Application.Abstracts.Auth;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class AccountServices
    {
        private readonly IRepository<User> userRepository;
        private readonly IPasswordHasher passwordHasher;

        public AccountServices(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task Registr(string username, string email, string password)
        {
            var hash = passwordHasher.Generate(password);
            var user = new User(Guid.NewGuid(), username, email, hash);
        }
    }
}

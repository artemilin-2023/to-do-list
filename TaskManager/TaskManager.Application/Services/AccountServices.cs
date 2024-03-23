using TaskManager.Application.Abstracts.Auth;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class AccountServices
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IJwtProvider jwtProvider;

        public AccountServices(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.jwtProvider = jwtProvider;
        }

        public async Task<string> Registr(string username, string email, string password)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user != null)
                throw new Exception($"User with email {email} already exist. Id: {user.Id}");

            var hash = passwordHasher.Generate(password);
            var newUser = new User(Guid.NewGuid(), username, email, hash);
            await userRepository.AddAsync(newUser);
            await userRepository.SaveAsync();

            var token = jwtProvider.Generate(newUser);
            return token;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new ArgumentNullException(nameof(user), message: $"Login failure, unable to find the user with the email {email}");

            if (!passwordHasher.Verify(password, user.PasswordHash))
                throw new Exception("Password virify failure");

            var token = jwtProvider.Generate(user);
            return token;
        }

        public Guid GetUserId(string token)
        {
            return jwtProvider.GetUserId(token);
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            await userRepository.DeleteAsync(id);
            await userRepository.SaveAsync();
        }
    }
}

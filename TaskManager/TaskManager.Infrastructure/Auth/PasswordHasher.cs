using TaskManager.Application.Abstracts.Auth;

namespace TaskManager.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => 
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hash) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}

using TaskManager.Domain;

namespace TaskManager.Application.Abstracts.Auth
{
    public interface IJwtProvider
    {
        public string Generate(User user);
    }
}

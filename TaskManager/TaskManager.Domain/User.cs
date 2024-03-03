namespace TaskManager.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username  { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(Guid id, string username, string email, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}

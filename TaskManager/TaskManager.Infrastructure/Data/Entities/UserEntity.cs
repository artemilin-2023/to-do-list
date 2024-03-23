namespace TaskManager.Infrastructure.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<BoardEntity> Boards { get; set; } = new();
        public List<CommentEntity> Comments { get; set; } = new();
    }
}

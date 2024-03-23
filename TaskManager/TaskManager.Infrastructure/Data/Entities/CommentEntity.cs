namespace TaskManager.Infrastructure.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string Text { get; set; }

        public UserEntity User { get; set; }
        public BoardEntity Board { get; set; }
    }
}

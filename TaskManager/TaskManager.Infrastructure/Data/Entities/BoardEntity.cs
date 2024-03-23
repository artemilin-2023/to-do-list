namespace TaskManager.Infrastructure.Data.Entities
{
    public class BoardEntity : BaseEntity
    {
        public string Title { get; set; }

        public UserEntity User { get; set; }
        public List<CommentEntity> Comments { get; set; } = new();
        public List<IssueEntity> Issues { get; set; } = new();
    }
}

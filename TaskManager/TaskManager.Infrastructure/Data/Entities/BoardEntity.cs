namespace TaskManager.Infrastructure.Data.Entities
{
    internal class BoardEntity : BaseEntity
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}

using TaskManager.Domain;

namespace TaskManager.Infrastructure.Data.Entities
{
    public class IssueEntity : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public IssueStatus IssueStatus { get; set; }

        public BoardEntity Board { get; set; }
    }
}

using TaskManager.Domain;

namespace TaskManager.Infrastructure.Data.Entities
{
    internal class IssueEntity : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid BoardId { get; set; }
        public IssueStatus IssueStatus { get; set; }
    }
}

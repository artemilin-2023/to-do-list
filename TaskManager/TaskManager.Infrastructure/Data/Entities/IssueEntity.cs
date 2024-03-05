using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure.Data.Entities
{
    internal class IssueEntity : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid BoardId { get; set; }
    }
}

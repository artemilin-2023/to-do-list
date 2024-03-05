using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure.Data.Entities
{
    internal class CommentEntity : BaseEntity
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public Guid BoardId { get; set; }
    }
}

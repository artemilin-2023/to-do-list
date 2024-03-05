using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure.Data.Entities
{
    internal class BoardEntity : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}

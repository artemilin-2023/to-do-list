using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Entities;
using TaskManager.Infrastructure.EntitiesConfiguration;

namespace TaskManager.Infrastructure
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        internal DbSet<UserEntity> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

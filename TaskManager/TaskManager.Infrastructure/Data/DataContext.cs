using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data.Entities;
using TaskManager.Infrastructure.Data.EntitiesConfiguration;

namespace TaskManager.Infrastructure.Data
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

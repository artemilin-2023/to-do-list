using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Infrastructure.Entities;

namespace TaskManager.Infrastructure.EntitiesConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                   .IsRequired();

            builder.Property(u => u.Email)
                   .IsRequired();

            builder.Property(u => u.PasswordHash)
                   .IsRequired();
        }
    }
}

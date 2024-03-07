using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.EntitiesConfiguration
{
    internal class BoardConfiguration : IEntityTypeConfiguration<BoardEntity>
    {
        public void Configure(EntityTypeBuilder<BoardEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired();

            builder.Property(b => b.UserId)
                   .IsRequired();
        }
    }
}

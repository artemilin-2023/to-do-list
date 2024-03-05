using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data.EntitiesConfiguration
{
    internal class IssueConfigurations : IEntityTypeConfiguration<IssueEntity>
    {
        public void Configure(EntityTypeBuilder<IssueEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreationTime)
                   .IsRequired();

            builder.Property(p => p.BoardId)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .IsRequired();
        }
    }
}

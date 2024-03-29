﻿using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data.Entities;
using TaskManager.Infrastructure.Data.EntitiesConfiguration;

namespace TaskManager.Infrastructure.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        internal DbSet<UserEntity> Users { get; private set; }
        internal DbSet<IssueEntity> Issues { get; private set; }
        internal DbSet<BoardEntity> Boards { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new IssueConfigurations());
            modelBuilder.ApplyConfiguration(new BoardConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

using LogLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogLog.Infrastructure.SqlLite
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() => Database.EnsureCreated();

        public DbSet<GroupEntity> Groups => Set<GroupEntity>();

        public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

        public DbSet<SubTaskEntity> SubTasks => Set<SubTaskEntity>();

        public DbSet<PeriodEntity> Periods => Set<PeriodEntity>();



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=loglog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupEntity>(group =>
            {
                group
                .HasKey(g => g.Id);

                group
                .HasMany(g => g.Tasks)
                .WithOne(t => t.Group)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TaskEntity>(task =>
            {
                task
                .HasKey(t => t.Id);

                task
                .HasMany(t => t.SubTasks)
                .WithOne(st => st.Task)
                .HasForeignKey(st => st.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SubTaskEntity>(subtask =>
            {
                subtask
                .HasKey(st => st.Id);

                subtask
                .HasMany(st => st.Periods)
                .WithOne(p => p.SubTask)
                .HasForeignKey(p => p.SubTaskId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PeriodEntity>(period =>
            {
                period
                .HasKey(p => p.Id);
            });

        }
    }
}

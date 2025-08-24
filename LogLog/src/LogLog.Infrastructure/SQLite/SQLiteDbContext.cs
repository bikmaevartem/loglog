using LogLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogLog.Infrastructure.SqlLite
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() => Database.EnsureCreated();

        public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

        public DbSet<SubTaskEntity> SubTasks => Set<SubTaskEntity>();

        public DbSet<PeriodEntity> Periods => Set<PeriodEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=loglog.db");
        }
    }
}

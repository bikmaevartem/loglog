using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SqlLite;
using Microsoft.EntityFrameworkCore;

namespace LogLog.Infrastructure.SQLite.Repositories
{
    public class TasksRepository : Repository<TaskEntity>, ITasksRepository
    {
        public TasksRepository(SQLiteDbContext context) : base(context)
        {
        }

        public async Task<TaskEntity?> FindByIdIncludeChildrenAsync(int id)
        {
            var task = await _dbSet
                .Include(t => t.SubTasks)
                .ThenInclude(st => st.Periods)
                .FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }

        public async Task<TaskEntity?> FindByNameIncludeChildrenAsync(string name)
        {
            var task = await _dbSet
                .Include(t => t.SubTasks)
                .ThenInclude(st => st.Periods)
                .FirstOrDefaultAsync(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return task;
        }
    }
}

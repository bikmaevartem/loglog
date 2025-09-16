using LogLog.Domain.Entities;

namespace LogLog.Domain.Interfaces.Repositories
{
    public interface ITasksRepository : IRepository<TaskEntity>
    {
        Task<TaskEntity?> FindByIdIncludeChildrenAsync(int id);

        Task<TaskEntity?> FindByNameIncludeChildrenAsync(string name);
    }
}

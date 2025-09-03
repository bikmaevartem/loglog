using LogLog.Domain.Entities;

namespace LogLog.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateAsync(string name, string? description);

        Task<TaskEntity> StartAsync(int id);

        Task<TaskEntity> StopAsync(int id);

        Task<TaskEntity> DeleteAsync(int id);

        Task<List<TaskEntity>> GetTasksOnlyAsync();
    }
}

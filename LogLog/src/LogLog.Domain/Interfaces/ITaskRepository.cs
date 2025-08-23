using LogLog.Domain.Entities;

namespace LogLog.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateAsync(TaskEntity task);

        
        Task<IReadOnlyList<TaskEntity>> GetAllAsync();

        Task<IReadOnlyList<TaskEntity>> SearchAsync(string? name, string? description);


        Task<TaskEntity?> StartAsync(int id);

        Task<TaskEntity?> StopAsync(int id);
    }
}

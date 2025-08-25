using LogLog.Domain.Interfaces;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Tasks.GetAllWithoutDetails
{
    public class GetAllTasksWithoutDetailsUseCase : IUseCase<GetAllTasksWithoutDetailsRequest, GetAllTasksWithoutDetailsResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksWithoutDetailsUseCase(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public async Task<GetAllTasksWithoutDetailsResponse> ExecuteAsync(GetAllTasksWithoutDetailsRequest request)
        {
            var tasks = await _taskRepository.GetTasksOnlyAsync();

            var responseTasks = tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                IsExecuting = t.IsExecuting,
                IsCompleted = t.IsCompleted,
            }).ToList();

            return new GetAllTasksWithoutDetailsResponse { Tasks = responseTasks};
        }
    }
}

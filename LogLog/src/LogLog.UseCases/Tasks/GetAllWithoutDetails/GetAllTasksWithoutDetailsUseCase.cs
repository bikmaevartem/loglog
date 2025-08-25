using LogLog.Domain.Interfaces;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Tasks.GetAllWithoutDetails
{
    public class GetAllTasksWithoutDetailsUseCase : IUseCase<GetAllTasksWithoutDetailsUseCaseRequest, GetAllTasksWithoutDetailsUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksWithoutDetailsUseCase(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public async Task<GetAllTasksWithoutDetailsUseCaseResponse> ExecuteAsync(GetAllTasksWithoutDetailsUseCaseRequest request)
        {
            var tasks = await _taskRepository.GetTasksOnlyAsync();

            var responseTasks = tasks.Select(t => new TaskUseCaseDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                IsExecuting = t.IsExecuting,
                IsCompleted = t.IsCompleted,
            }).ToList();

            return new GetAllTasksWithoutDetailsUseCaseResponse { Tasks = responseTasks};
        }
    }
}

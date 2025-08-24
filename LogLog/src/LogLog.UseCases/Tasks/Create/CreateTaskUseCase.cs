using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Create
{
    public class CreateTaskUseCase : IUseCase<CreateTaskRequest, CreateTaskResponse>
    {
        private readonly ITaskRepository _taskRepository;

        CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<CreateTaskResponse> ExecuteAsync(CreateTaskRequest request)
        {
            var task = await _taskRepository.CreateAsync(name: request.Name, description: request.Description);
            return new CreateTaskResponse { TaskId = task.Id };
        }
    }
}

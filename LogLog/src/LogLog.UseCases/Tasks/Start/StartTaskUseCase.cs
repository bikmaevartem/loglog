using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Start
{
    public class StartTaskUseCase : IUseCase<StartTaskRequest, StartTaskResponse>
    {
       private readonly ITaskRepository _taskRepository;

        public StartTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<StartTaskResponse> ExecuteAsync(StartTaskRequest request)
        {
            await _taskRepository.StartAsync(request.TaskId);

            return new StartTaskResponse();
        }
    }
}

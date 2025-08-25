using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Start
{
    public class StartTaskUseCase : IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse>
    {
       private readonly ITaskRepository _taskRepository;

        public StartTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<StartTaskUseCaseResponse> ExecuteAsync(StartTaskUseCaseRequest request)
        {
            await _taskRepository.StartAsync(request.TaskId);

            return new StartTaskUseCaseResponse();
        }
    }
}

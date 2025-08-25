using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Start
{
    public class StartTaskUseCase : BaseUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse>
    {
       private readonly ITaskRepository _taskRepository;

        public StartTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override async Task<StartTaskUseCaseResponse> ExecuteAsync(StartTaskUseCaseRequest request)
        {
            var task = await _taskRepository.StartAsync(request.TaskId);
            var taskDto = ConvertDomainModelToDto(task);

            return new StartTaskUseCaseResponse(taskDto);
        }
    }
}

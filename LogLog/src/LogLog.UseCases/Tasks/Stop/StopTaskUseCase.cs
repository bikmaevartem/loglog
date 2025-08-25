using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Stop
{
    public class StopTaskUseCase : BaseUseCase<StopTaskUseCaseRequest, StopTaskUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public StopTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override async Task<StopTaskUseCaseResponse> ExecuteAsync(StopTaskUseCaseRequest request)
        {
            var task = await _taskRepository.StopAsync(request.TaskId);

            return new StopTaskUseCaseResponse(Task: ConvertDomainModelToDto(task));
        }
    }
}

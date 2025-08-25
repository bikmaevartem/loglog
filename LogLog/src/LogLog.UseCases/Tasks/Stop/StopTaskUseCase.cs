using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Stop
{
    public class StopTaskUseCase : IUseCase<StopTaskUseCaseRequest, StopTaskUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public StopTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<StopTaskUseCaseResponse> ExecuteAsync(StopTaskUseCaseRequest request)
        {
            await _taskRepository.StopAsync(request.TaskId);

            return new StopTaskUseCaseResponse();
        }
    }
}

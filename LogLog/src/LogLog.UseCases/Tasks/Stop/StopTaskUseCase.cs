using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Stop
{
    public class StopTaskUseCase : IUseCase<StopTaskRequest, StopTaskResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public StopTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<StopTaskResponse> ExecuteAsync(StopTaskRequest request)
        {
            await _taskRepository.StopAsync(request.TaskId);

            return new StopTaskResponse();
        }
    }
}

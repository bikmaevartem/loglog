using LogLog.Domain.Interfaces;

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

            var responseTasks = tasks.Select(t => new { });

            return new GetAllTasksWithoutDetailsResponse();
        }
    }
}

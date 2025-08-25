using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.GetAllWithoutDetails
{
    public class GetAllTasksWithoutDetailsUseCase : BaseUseCase<GetAllTasksWithoutDetailsUseCaseRequest, GetAllTasksWithoutDetailsUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksWithoutDetailsUseCase(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public override async Task<GetAllTasksWithoutDetailsUseCaseResponse> ExecuteAsync(GetAllTasksWithoutDetailsUseCaseRequest request)
        {
            var tasks = await _taskRepository.GetTasksOnlyAsync();

            var responseTasks = tasks.Select(t => ConvertDomainModelToDto(t)).ToList();

            return new GetAllTasksWithoutDetailsUseCaseResponse(Tasks: responseTasks);
        }
    }
}

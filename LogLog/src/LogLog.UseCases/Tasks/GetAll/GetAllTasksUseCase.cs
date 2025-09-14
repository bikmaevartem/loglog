using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.GetAll
{
    public class GetAllTasksUseCase : BaseUseCase<GetAllTasksUseCaseRequest, GetAllTasksUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksUseCase(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public override async Task<GetAllTasksUseCaseResponse> ExecuteAsync(GetAllTasksUseCaseRequest request)
        {
            var tasks = await _taskRepository.GetTasksOnlyAsync();

            var responseTasks = tasks.Select(t => ConvertDomainModelToDto(t)).ToList();

            return new GetAllTasksUseCaseResponse(Tasks: responseTasks);
        }
    }
}

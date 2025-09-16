using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Tasks.GetAll
{
    public class GetAllTasksUseCase : BaseTasksUseCase<GetAllTasksUseCaseRequest, GetAllTasksUseCaseResponse>
    {
        private readonly ITasksRepository _tasksRepository;
        public GetAllTasksUseCase(ITasksRepository tasksRepository) 
        {
            _tasksRepository = tasksRepository;
        }

        public override async Task<GetAllTasksUseCaseResponse> ExecuteAsync(GetAllTasksUseCaseRequest request)
        {
            var tasks = await _tasksRepository.GetAllByParentIdAsync(request.GroupId);

            var responseTasks = tasks.Select(t => ConvertEntityToDto(t)).ToList();

            return new GetAllTasksUseCaseResponse(Tasks: responseTasks);
        }
    }
}

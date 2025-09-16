using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Tasks.Find
{
    public class FindTaskUseCase : BaseTasksUseCase<FindTaskUseCaseRequest, FindTaskUseCaseResponse>
    {
        private readonly ITasksRepository _tasksRepository;

        public FindTaskUseCase(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async override Task<FindTaskUseCaseResponse> ExecuteAsync(FindTaskUseCaseRequest request)
        {
            var taskEntity = request.Id.HasValue
                ? await _tasksRepository.FindByIdAsync(request.Id.Value)
                : !string.IsNullOrEmpty(request.Name)
                    ? await _tasksRepository.FindByNameAsync(request.Name)
                    : null;

            return new FindTaskUseCaseResponse(ConvertEntityToDto(taskEntity));
        }
    }
}

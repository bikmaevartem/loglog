using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Tasks.Delete
{
    public class DeleteTaskUseCase : BaseTasksUseCase<DeleteTaskUseCaseRequest, DeleteTaskUseCaseResponse>
    {
        private readonly ITasksRepository _tasksRepository;

        public DeleteTaskUseCase(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public override async Task<DeleteTaskUseCaseResponse> ExecuteAsync(DeleteTaskUseCaseRequest request)
        {
            var taskEntity = await _tasksRepository.FindByIdAsync(request.TaskId);

            if (taskEntity == null)
            {
                await _tasksRepository.DeleteAsync(request.TaskId);
            }

            return new DeleteTaskUseCaseResponse(ConvertEntityToDto(taskEntity));
        }
    }
}

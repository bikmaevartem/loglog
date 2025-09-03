using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Delete
{
    public class DeleteTaskUseCase : BaseUseCase<DeleteTaskUseCaseRequest, DeleteTaskUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override async Task<DeleteTaskUseCaseResponse> ExecuteAsync(DeleteTaskUseCaseRequest request)
        {
            var task = await _taskRepository.DeleteAsync(request.TaskId);

            return new DeleteTaskUseCaseResponse(Task: ConvertDomainModelToDto(task));
        }
    }
}

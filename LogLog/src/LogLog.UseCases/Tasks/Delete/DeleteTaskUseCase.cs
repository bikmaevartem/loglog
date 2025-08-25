using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Delete
{
    public class DeleteTaskUseCase : IUseCase<DeleteTaskUseCaseRequest, DeleteTaskUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<DeleteTaskUseCaseResponse> ExecuteAsync(DeleteTaskUseCaseRequest request)
        {
            await _taskRepository.DeleteAsync(request.TaskId);

            return new DeleteTaskUseCaseResponse();
        }
    }
}

using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Create
{
    public class CreateTaskUseCase : BaseUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse>
    {
        private readonly ITaskRepository _taskRepository;

        CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override async Task<CreateTaskUseCaseResponse> ExecuteAsync(CreateTaskUseCaseRequest request)
        {
            var task = await _taskRepository.CreateAsync(name: request.Name, description: request.Description);
            return new CreateTaskUseCaseResponse(Task: ConvertDomainModelToDto(task));
        }
    }
}

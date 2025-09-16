using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Tasks.Create
{
    public class CreateTaskUseCase : BaseTasksUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse>
    {
        private readonly ITasksRepository _tasksRepository;

        public CreateTaskUseCase(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public override async Task<CreateTaskUseCaseResponse> ExecuteAsync(CreateTaskUseCaseRequest request)
        {
            var taskEntity = new TaskEntity(
                groupId: request.GroupId,
                name: request.Name,
                description: request.Description
                );

            taskEntity = await _tasksRepository.AddAsync(taskEntity);

            #pragma warning disable CS8604
            return new CreateTaskUseCaseResponse(ConvertEntityToDto(taskEntity));
            #pragma warning restore CS8604
        }
    }
}

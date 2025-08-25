using LogLog.Domain.Entities;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases
{
    public abstract class BaseUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
    {
        public abstract Task<TResponse> ExecuteAsync(TRequest request);

        protected TaskUseCaseDto ConvertDomainModelToDto(TaskEntity task)
        {
            var taskDto = new TaskUseCaseDto(
                Id: task.Id,
                Name: task.Name,
                Description: task.Description,
                IsExecuting: task.IsExecuting,
                IsCompleted: task.IsCompleted
                );

            return taskDto;
        }

    }
}

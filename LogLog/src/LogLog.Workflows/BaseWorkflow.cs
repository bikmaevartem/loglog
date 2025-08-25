using LogLog.UseCases.Dto;
using LogLog.Workflows.Dto;

namespace LogLog.Workflows
{
    public abstract class BaseWorkflow<TRequest, TResponse> : IWorkflow<TRequest, TResponse>
    {
        public abstract Task<TResponse> ExecuteAsync(TRequest request);

        protected TaskWorkflowDto ConvertUseCaseModelToDto(TaskUseCaseDto task)
        {
            var taskDto = new TaskWorkflowDto(
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

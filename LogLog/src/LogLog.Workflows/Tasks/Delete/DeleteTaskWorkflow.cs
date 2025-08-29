using LogLog.UseCases;
using LogLog.UseCases.Tasks.Delete;

namespace LogLog.Workflows.Tasks.Delete
{
    public class DeleteTaskWorkflow : IWorkflow<DeleteTaskWorkflowRequest, DeleteTaskWorkflowResponse>
    {
        private readonly IUseCase<DeleteTaskUseCaseRequest, DeleteTaskUseCaseResponse> _deleteTaskUseCase;

        public DeleteTaskWorkflow(IUseCase<DeleteTaskUseCaseRequest, DeleteTaskUseCaseResponse> deleteTaskUseCase)
        {
            _deleteTaskUseCase = deleteTaskUseCase;
        }

        public async Task<DeleteTaskWorkflowResponse> ExecuteAsync(DeleteTaskWorkflowRequest request)
        {
            var useCaseResponse = await _deleteTaskUseCase.ExecuteAsync(new DeleteTaskUseCaseRequest(request.TaskId));
            return new DeleteTaskWorkflowResponse(useCaseResponse.Task);
        }
    }
}

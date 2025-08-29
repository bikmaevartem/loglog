using LogLog.UseCases;
using LogLog.UseCases.Tasks.Start;

namespace LogLog.Workflows.Tasks.Start
{
    public class StartTaskWorkflow : IWorkflow<StartTaskWorkflowRequest, StartTaskWorkflowResponse>
    {
        private readonly IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> _startTaskUseCase;

        public StartTaskWorkflow(IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> startTaskUseCase)
        {
            _startTaskUseCase = startTaskUseCase;
        }

        public async Task<StartTaskWorkflowResponse> ExecuteAsync(StartTaskWorkflowRequest request)
        {
            var useCaseResponse = await _startTaskUseCase.ExecuteAsync(new StartTaskUseCaseRequest(request.TaskId));
            return new StartTaskWorkflowResponse(useCaseResponse.Task);
        }
    }
}

using LogLog.UseCases;
using LogLog.UseCases.Tasks.Stop;

namespace LogLog.Workflows.Tasks.Stop
{
    public class StopTaskWorkflow : IWorkflow<StopTaskWorkflowRequest, StopTaskWorkflowResponse>
    {
        private readonly IUseCase<StopTaskUseCaseRequest, StopTaskWorkflowResponse> _stopTaskUseCase;

        public StopTaskWorkflow(IUseCase<StopTaskUseCaseRequest, StopTaskWorkflowResponse> stopTaskUseCase)
        {
            _stopTaskUseCase = stopTaskUseCase;
        }

        public async Task<StopTaskWorkflowResponse> ExecuteAsync(StopTaskWorkflowRequest request)
        {
            var useCaseResponse = await _stopTaskUseCase.ExecuteAsync(new StopTaskUseCaseRequest(request.TaskId));

            return new StopTaskWorkflowResponse(useCaseResponse.Task);
        }
    }
}

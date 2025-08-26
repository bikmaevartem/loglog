using LogLog.UseCases;
using LogLog.UseCases.Tasks.Create;
using LogLog.UseCases.Tasks.Start;

namespace LogLog.Workflows.Tasks.CreateAndStart
{
    public class CreateAndStartTaskWorkflow : IWorkflow<CreateAndStartTaskWorkflowRequest, CreateAndStartTaskWorkflowResponse>
    {
        private readonly IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> _createTaskUseCase;
        private readonly IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> _startTaskUseCase;

        public CreateAndStartTaskWorkflow(
            IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> createTaskUseCase,
            IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> startTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
            _startTaskUseCase = startTaskUseCase;
        }

        public async Task<CreateAndStartTaskWorkflowResponse> ExecuteAsync(CreateAndStartTaskWorkflowRequest request)
        {
            var createTaskUseCaseResponse = await _createTaskUseCase.ExecuteAsync(new CreateTaskUseCaseRequest(
                Name: request.Name, Description: request.Description));

            var startTaskUseCaseResponse = await _startTaskUseCase.ExecuteAsync(new StartTaskUseCaseRequest(
                TaskId: createTaskUseCaseResponse.Task.Id));

            return new CreateAndStartTaskWorkflowResponse(startTaskUseCaseResponse.Task);
        }
    }
}

using LogLog.UseCases;
using LogLog.UseCases.Tasks.Create;

namespace LogLog.Workflows.Tasks.Create
{
    public class CreateTaskWorkflow : IWorkflow<CreateTaskWorkflowRequest, CreateTaskWorkflowResponse>
    {
        private readonly IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> _createTaskUseCase;

        public CreateTaskWorkflow(IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> createTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
        }

        public async Task<CreateTaskWorkflowResponse> ExecuteAsync(CreateTaskWorkflowRequest request)
        {
            var response = await _createTaskUseCase.ExecuteAsync(new CreateTaskUseCaseRequest(
                Name: request.Name,
                Description: request.Description
                ));


            return new CreateTaskWorkflowResponse(response.Task);
        }
    }
}

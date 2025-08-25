using LogLog.UseCases;
using LogLog.UseCases.Tasks.Create;

namespace LogLog.Workflows.Tasks.Create
{
    public class CreateTaskWorkflow : BaseWorkflow<CreateTaskWorkflowRequest, CreateTaskWorkflowResponse>
    {
        private readonly IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> _createTaskUseCase;

        public CreateTaskWorkflow(IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> createTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
        }

        public override async Task<CreateTaskWorkflowResponse> ExecuteAsync(CreateTaskWorkflowRequest request)
        {
            var response = await _createTaskUseCase.ExecuteAsync(new CreateTaskUseCaseRequest(
                Name: request.Name,
                Description: request.Description
                ));


            return new CreateTaskWorkflowResponse(ConvertUseCaseModelToDto(response.Task));
        }
    }
}

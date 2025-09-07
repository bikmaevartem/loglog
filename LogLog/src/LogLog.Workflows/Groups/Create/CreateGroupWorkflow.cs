using LogLog.UseCases;
using LogLog.UseCases.Groups.Create;

namespace LogLog.Workflows.Groups.Create
{
    public class CreateGroupWorkflow : IWorkflow<CreateGroupWorkflowRequest, CreateGroupWorkflowResponse>
    {
        private readonly IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> _createGroupUseCase;

        public CreateGroupWorkflow(IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> createGroupUseCase)
        {
            _createGroupUseCase = createGroupUseCase;
        }

        public async Task<CreateGroupWorkflowResponse> ExecuteAsync(CreateGroupWorkflowRequest request)
        {
            var useCaseResponse = await _createGroupUseCase.ExecuteAsync(new CreateGroupUseCaseRequest(
                Name: request.Name, Description: request.Description));

            return new CreateGroupWorkflowResponse(useCaseResponse.Group);
        }
    }
}

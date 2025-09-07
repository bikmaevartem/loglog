using LogLog.UseCases;
using LogLog.UseCases.Groups.GetAll;

namespace LogLog.Workflows.Groups.GetAll
{
    public class GetAllGroupsWorkflow : IWorkflow<GetAllGroupsWorkflowRequest, GetAllGroupsWorkflowResponse>
    {
        private readonly IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> _getAllGroupsUseCase;
        public GetAllGroupsWorkflow(IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> getAllGroupsUseCase)
        {
            _getAllGroupsUseCase = getAllGroupsUseCase;
        }

        public async Task<GetAllGroupsWorkflowResponse> ExecuteAsync(GetAllGroupsWorkflowRequest request)
        {
            var useCaseResponse = await _getAllGroupsUseCase.ExecuteAsync(new GetAllGroupsUseCaseRequest());
            
            return new GetAllGroupsWorkflowResponse(useCaseResponse.Groups);
        }
    }
}

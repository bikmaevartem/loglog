using LogLog.UseCases.Dto;

namespace LogLog.Workflows.Groups.GetAll
{
    public record GetAllGroupsWorkflowResponse(List<GroupDto> Groups);
}

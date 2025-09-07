using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Groups.GetAll
{
    public record GetAllGroupsUseCaseResponse(List<GroupDto> Groups);
}

using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Tasks.GetAllWithoutDetails
{
    public record GetAllTasksWithoutDetailsUseCaseResponse(List<TaskDto> Tasks);
}

using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Tasks.GetAll
{
    public record GetAllTasksUseCaseResponse(List<TaskDto> Tasks);
}

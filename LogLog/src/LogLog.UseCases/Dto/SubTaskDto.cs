namespace LogLog.UseCases.Dto
{
    public record SubTaskDto(
        int Id,
        string Name,
        string? Description,
        bool IsExecuting,
        bool IsCompleted
        );
}

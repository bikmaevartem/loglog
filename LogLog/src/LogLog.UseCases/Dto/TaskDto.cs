namespace LogLog.UseCases.Dto
{
    public record TaskDto(
        int Id,
        string Name,
        string? Description,
        bool IsExecuting,
        bool IsCompleted
        );
}

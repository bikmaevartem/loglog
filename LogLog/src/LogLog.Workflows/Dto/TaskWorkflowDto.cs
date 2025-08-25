namespace LogLog.Workflows.Dto
{
    public record TaskWorkflowDto(
        int Id,
        string Name,
        string? Description,
        bool IsExecuting,
        bool IsCompleted
        );
}

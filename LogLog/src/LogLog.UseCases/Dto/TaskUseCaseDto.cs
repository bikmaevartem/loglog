namespace LogLog.UseCases.Dto
{
    public record TaskUseCaseDto(
        int Id,
        string Name,
        string? Description,
        bool IsExecuting,
        bool IsCompleted
        );
}

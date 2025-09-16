namespace LogLog.UseCases.Dto
{
    public record TaskDto(
        int Id,
        string Name,
        string? Description,
        DateTimeOffset Created,
        DateTimeOffset Updated
        );
}

namespace LogLog.UseCases.Dto
{
    public record GroupDto(
        int Id,
        string Name,
        string? Description,
        DateTimeOffset Created,
        DateTimeOffset Updated
        );
}

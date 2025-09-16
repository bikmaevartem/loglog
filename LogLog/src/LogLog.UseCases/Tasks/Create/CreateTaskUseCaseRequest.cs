namespace LogLog.UseCases.Tasks.Create
{
    public record CreateTaskUseCaseRequest(int GroupId, string Name, string? Description = null);
}

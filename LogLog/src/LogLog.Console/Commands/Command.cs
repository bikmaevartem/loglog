namespace LogLog.Console.Commands
{
    public record Command(CommandType Type, string? rawType, string? parameters);
}

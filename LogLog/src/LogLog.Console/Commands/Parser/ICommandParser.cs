namespace LogLog.Console.Commands.Parser
{
    public interface ICommandParser
    {
        Command Parse(string? command);
    }
}

namespace LogLog.Console.Commands.Executor
{
    public interface ICommandExecutor
    {
        Task ExecuteAsync(Command command);
    }
}

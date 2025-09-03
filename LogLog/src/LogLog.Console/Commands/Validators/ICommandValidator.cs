namespace LogLog.Console.Commands.Validators
{
    public interface ICommandValidator
    {
        bool IsValid(Command command);
    }
}

namespace LogLog.Console.Commands.Validators
{
    public class CommandValidator : ICommandValidator
    {
        public bool IsValid(Command command)
        {
            return command.Type != CommandType.Unknown;
        }
    }
}

namespace LogLog.Console.Commands.Validators
{
    public class CliCommandValidator : ICommandValidator
    {
        public bool IsValid(Command command)
        {
            return command.Type != CommandType.Unknown;
        }
    }
}

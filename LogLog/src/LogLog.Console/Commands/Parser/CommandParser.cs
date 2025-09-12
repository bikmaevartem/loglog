namespace LogLog.Console.Commands.Parser
{
    public class CommandParser : ICommandParser
    {
        public Command Parse(string? command)
        {
            if (!string.IsNullOrEmpty(command))
            {
                command = command.Trim();
            }

            var commandRawType = GetRawTypeFromCommand(command);
            var commandType = GetTypeFromRawType(commandRawType);
            var parameters = GetParametersFromCommand(command);

            return new Command(Type: commandType, rawType: commandRawType, parameters);
        }

        private string? GetRawTypeFromCommand(string? command)
        {
            string? result = null;

            if (!string.IsNullOrEmpty(command))
            {
                var spaceIndex = command.IndexOf(" ");

                result = spaceIndex < 0
                    ? command
                    : command.Substring(0, spaceIndex);
            }

            return result;
        }

        private CommandType GetTypeFromRawType(string? rawType)
        {
            if (!Enum.TryParse<CommandType>(rawType, true, out var result))
            {
                result = CommandType.Unknown;
            }

            return result;
        }

        private string? GetParametersFromCommand(string? command)
        {
            string? result = null;

            if (!string.IsNullOrEmpty(command))
            {
                var spaceIndex = command.IndexOf(" ");
                result = spaceIndex < 0
                    ? string.Empty
                    : command.Substring(spaceIndex + 1);
            }

            return result;
        }
    }
}

using LogLog.Console.Commands.Executor;
using LogLog.Console.Shell;
using LogLog.Console.State;

namespace LogLog.Console.Commands.Executors
{
    public abstract class BaseCommandExecutor : ICommandExecutor
    {
        public virtual async Task ExecuteAsync(Command command)
        {
            switch(command.Type)
            {
                case CommandType.Create:
                    await ExecuteCreateAsync(command);
                    break;

                case CommandType.CreateAndStart:
                    await ExecuteCreateAndStartAsync(command);
                    break;

                case CommandType.Open:
                    await ExecuteOpenAsync(command);
                    break;

                case CommandType.Start:
                    await ExecuteStartAsync(command);
                    break;

                case CommandType.Stop:
                    await ExecuteStopAsync(command);
                    break;

                case CommandType.Delete:
                    await ExecuteDeleteAsync(command);
                    break;

                case CommandType.List:
                    await ExecuteListAsync(command);
                    break;

                case CommandType.Back:
                    await ExecuteBackAsync(command);
                    break;

                case CommandType.Unknown:
                    PrintMessageUnknownCommand(command);
                    break;

                default:
                    PrintMessageUnsupportedCommand(command);
                    break;
            }
        }

        #region Execute commnds

        protected virtual Task ExecuteCreateAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteCreateAndStartAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteOpenAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteStartAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteStopAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteDeleteAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteListAsync(Command command)
        {
            PrintMessageUnsupportedCommand(command);

            return Task.CompletedTask;
        }

        protected virtual Task ExecuteBackAsync(Command command)
        {
            Context.Current.RemoveLastContext();

            return Task.CompletedTask;
        }

        #endregion

        protected void PrintMessageUnknownCommand(Command command)
        {
            PrintService.PrintWarningLn($"Unknown command! Command - {command.rawType}. Parameters - {command.parameters}.");
        }

        protected void PrintMessageUnsupportedCommand(Command command)
        {
            PrintService.PrintWarningLn($"This command unsuppoted in this context. Command - {command.Type.ToString()}. Parameters - {command.parameters}.");
        }

        

        protected int? ConvertCommandParametersToInt(Command command)
        {
            if (int.TryParse(command.parameters, out var result))
            {
                return result;
            }

            return null;
        }

    }
}

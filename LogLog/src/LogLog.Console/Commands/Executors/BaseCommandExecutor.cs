using LogLog.Console.Commands.Executor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Console.Commands.Executors
{
    public abstract class BaseCommandExecutor : ICommandExecutor
    {
        public abstract Task ExecuteAsync(Command command);

        protected void ExecuteBackCommand()
        {
            Context.Context.Current.RemoveLastContext();
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

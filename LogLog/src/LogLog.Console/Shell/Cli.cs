using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Parser;
using LogLog.Console.State;

namespace LogLog.Console.Shell
{
    public partial class Cli : IShell
    {
        private readonly ICommandParser _commandParser;
        private readonly ICommandExecutor _commandExecutor;

        

        public Cli(
            ICommandParser commandParser,
            ICommandExecutor commandExecutor)
        {
            _commandParser = commandParser;
            _commandExecutor = commandExecutor;
        }

        public async Task Run()
        {
            do
            {
                PrintContext();
                // TODO show info, like last/top tasks or subtasks

                var rawCommand = System.Console.ReadLine();
                var command = _commandParser.Parse(rawCommand);
                await _commandExecutor.ExecuteAsync(command);
            } 
            while (true);
        }

        private void PrintLine(string? str)
        {
            System.Console.Write(str);
        }

        private void PrintContext()
        {
            PrintLine(Context.Current.ToString());
        }


    }
}

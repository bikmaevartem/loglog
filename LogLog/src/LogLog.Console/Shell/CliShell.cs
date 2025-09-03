using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Parser;
using LogLog.Console.Commands.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Console.Shell
{
    public class CliShell : IShell
    {
        private readonly ICommandParser _commandParser;
        private readonly ICommandValidator _commandValidator;
        private readonly ICommandExecutor _commandExecutor;

        public CliShell(
            ICommandParser commandParser,
            ICommandValidator commandValidator,
            ICommandExecutor commandExecutor)
        {
            _commandParser = commandParser;
            _commandValidator = commandValidator;
            _commandExecutor = commandExecutor;
        }

        public void Run()
        {
            do
            {
                // TODO show info, like last/top tasks or subtasks
                // TODO show context

                var rawCommand = System.Console.ReadLine();
                var command = _commandParser.Parse(rawCommand);
                var isCommandValid = _commandValidator.IsValid(command);
                if (isCommandValid)
                {
                    _commandExecutor.Execute(command);
                }

            } 
            while (true);
        }

        public void Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}

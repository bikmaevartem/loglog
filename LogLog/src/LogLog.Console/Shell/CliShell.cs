using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Parser;
using LogLog.Console.Commands.Validators;
using LogLog.Console.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Console.Shell
{
    public partial class CliShell : IShell
    {
        private readonly IContext _context;

        private readonly ICommandParser _commandParser;
        private readonly ICommandValidator _commandValidator;
        private readonly ICommandExecutor _commandExecutor;

        

        public CliShell(
            IContext context,
            ICommandParser commandParser,
            ICommandValidator commandValidator,
            ICommandExecutor commandExecutor)
        {
            _context = context;

            _commandParser = commandParser;
            _commandValidator = commandValidator;
            _commandExecutor = commandExecutor;
        }

        public void Run()
        {
            do
            {
                PrintContext();
                // TODO show info, like last/top tasks or subtasks


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


        private void PrintLine(string? str)
        {
            System.Console.Write(str);
        }

        private void PrintContext()
        {
            PrintLine(_context.ToString());
        }


    }
}

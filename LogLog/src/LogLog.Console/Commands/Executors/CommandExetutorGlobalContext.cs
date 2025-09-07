using LogLog.Console.Commands.Executor;
using LogLog.UseCases.Groups.Create;
using LogLog.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Console.Commands.Executors
{
    public class CommandExetutorGlobalContext : ICommandExecutor
    {
        private readonly IWorkflow<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> _createGroupWorkflow;

        public void Execute(Command command)
        {
        }
    }
}

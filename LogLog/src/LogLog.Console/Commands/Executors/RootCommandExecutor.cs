using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Executors.Workspace;
using LogLog.Console.Context;

namespace LogLog.Console.Commands.Executors
{
    public class RootCommandExecutor : ICommandExecutor
    {
        private readonly IContext _context;
        private readonly IWorkspaceCommandExecutor _workspaceCommandExecutor;

        public RootCommandExecutor(
            IContext context,
            IWorkspaceCommandExecutor workspaceCommandExecutor
            )
        {
            _context = context;

            _workspaceCommandExecutor = workspaceCommandExecutor;
        }

        public async Task ExecuteAsync(Command command)
        {
            switch (_context.Type)
            {
                case ContextType.Workspace:
                    await _workspaceCommandExecutor.ExecuteAsync(command);
                    break;
            }
        }
    }
}

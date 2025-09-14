using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Executors.Group;
using LogLog.Console.Commands.Executors.Workspace;
using LogLog.Console.Context;

namespace LogLog.Console.Commands.Executors
{
    public class RootCommandExecutor : ICommandExecutor
    {
        private readonly IWorkspaceCommandExecutor _workspaceCommandExecutor;
        private readonly IGroupCommandExecutor _groupCommandExecutor;

        public RootCommandExecutor(
            IWorkspaceCommandExecutor workspaceCommandExecutor,
            IGroupCommandExecutor groupCommandExecutor
            )
        {
            _workspaceCommandExecutor = workspaceCommandExecutor;
            _groupCommandExecutor = groupCommandExecutor;
        }

        public async Task ExecuteAsync(Command command)
        {
            switch (Context.Context.Current.Type)
            {
                case ContextType.Workspace:
                    await _workspaceCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Group:
                    await _groupCommandExecutor.ExecuteAsync(command);
                    break;
            }
        }
    }
}

using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Executors.Workspace;
using LogLog.Console.Context;

namespace LogLog.Console.Commands.Executors
{
    public class RootCommandExecutor : ICommandExecutor
    {
        private readonly IWorkspaceCommandExecutor _workspaceCommandExecutor;

        public RootCommandExecutor(
            IWorkspaceCommandExecutor workspaceCommandExecutor
            )
        {
            _workspaceCommandExecutor = workspaceCommandExecutor;
        }

        public async Task ExecuteAsync(Command command)
        {
            switch (Context.Context.Current.Type)
            {
                case ContextType.Workspace:
                    await _workspaceCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Group:
                    break;
            }
        }
    }
}

using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Executors.GroupContext;
using LogLog.Console.Commands.Executors.PeriodContext;
using LogLog.Console.Commands.Executors.SubTaskContext;
using LogLog.Console.Commands.Executors.TaskContext;
using LogLog.Console.Commands.Executors.WorkspaceContext;
using LogLog.Console.State;

namespace LogLog.Console.Commands.Executors
{
    public class RootCommandExecutor : ICommandExecutor
    {
        private readonly IWorkspaceContextCommandExecutor _workspaceContextCommandExecutor;
        private readonly IGroupContextCommandExecutor _groupContextCommandExecutor;
        private readonly ITaskContextCommandExecutor _taskContextCommandExecutor;
        private readonly ISubTaskContextCommandExecutor _subTaskContextCommandExecutor;
        private readonly IPeriodContextCommandExecutor _periodContextCommandExecutor;

        public RootCommandExecutor(
            IWorkspaceContextCommandExecutor workspaceContextCommandExecutor,
            IGroupContextCommandExecutor groupContextCommandExecutor,
            ITaskContextCommandExecutor taskContextCommandExecutor,
            ISubTaskContextCommandExecutor subTaskContextCommandExecutor,
            IPeriodContextCommandExecutor periodContextCommandExecutor
            )
        {
            _workspaceContextCommandExecutor = workspaceContextCommandExecutor;
            _groupContextCommandExecutor = groupContextCommandExecutor;
            _taskContextCommandExecutor = taskContextCommandExecutor;
            _subTaskContextCommandExecutor = subTaskContextCommandExecutor;
            _periodContextCommandExecutor = periodContextCommandExecutor;
        }

        public async Task ExecuteAsync(Command command)
        {
            switch (Context.Current.Type)
            {
                case ContextType.Workspace:
                    await _workspaceContextCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Group:
                    await _groupContextCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Task:
                    await _taskContextCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Subtask:
                    await _subTaskContextCommandExecutor.ExecuteAsync(command);
                    break;

                case ContextType.Period:
                    await _periodContextCommandExecutor.ExecuteAsync(command);
                    break;

                default:
                    // TODO
                    break;
            }
        }
    }
}

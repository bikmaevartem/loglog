using LogLog.Console.Context;

namespace LogLog.Console.Contexts.Types
{
    public class WorkspaceContext : IContext
    {
        private const string _contextName = "Workspace";

        public WorkspaceContext()
        {
            Type = ContextType.Workspace;
            Id = 0;
        }

        public ContextType Type { get; private set; }

        public int Id { get; private set; }

        public IContext? Child { get; set; }

        public override string ToString()
        {
            return Child == null
                ? $"{_contextName}>"
                : $"{_contextName}{Child.ToString()}";
        }
    }
}

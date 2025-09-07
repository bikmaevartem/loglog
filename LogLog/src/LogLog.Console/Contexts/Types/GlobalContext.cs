using LogLog.Console.Context;

namespace LogLog.Console.Contexts.Types
{
    public class GlobalContext : IContext
    {
        private const string _contextName = "Log";

        public GlobalContext()
        {
            Type = ContextType.Global;
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

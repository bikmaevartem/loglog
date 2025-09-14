namespace LogLog.Console.Context
{
    public class Context : BaseContext
    {

        public static IContext Current { get; private set; } = ContextFactory.CreateContext(ContextType.Workspace);

        public Context(ContextType type) : this(type, 0, type.ToString()) { }

        public Context(ContextType type, int id, string name)
        {
            _type = type;
            _id = id;
            _name = name;
        }
    }
}

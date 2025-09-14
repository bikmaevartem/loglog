namespace LogLog.Console.Context
{
    public interface IContext
    {
        ContextType Type { get; }

        int Id { get; }

        string Name { get; }

        IContext? Child { get; }

        void AddContext(IContext child);

        void RemoveLastContext();

    }
}

namespace LogLog.Console.Context
{
    public interface IContext
    {
        ContextType Type { get; }

        int Id { get; }

        IContext? Child { get; set; }

    }
}

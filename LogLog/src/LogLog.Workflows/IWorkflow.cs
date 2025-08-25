namespace LogLog.Workflows
{
    public interface IWorkflow<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}

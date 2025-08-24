﻿namespace LogLog.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}

using LogLog.Domain.Interfaces;

namespace LogLog.UseCases.Tasks.Stop
{
    public class StopTaskUseCase : BaseTasksUseCase<StopTaskUseCaseRequest, StopTaskUseCaseResponse>
    {

        public StopTaskUseCase()
        {
        }

        public override async Task<StopTaskUseCaseResponse> ExecuteAsync(StopTaskUseCaseRequest request)
        {
            return new StopTaskUseCaseResponse(Task: null);
        }
    }
}

using LogLog.Console.State;
using LogLog.UseCases;
using LogLog.UseCases.Dto;
using LogLog.UseCases.Tasks.Create;
using LogLog.UseCases.Tasks.Find;
using LogLog.UseCases.Tasks.Start;

namespace LogLog.Console.Commands.Executors.GroupContext
{
    public class GroupContextCommandExecutor : BaseCommandExecutor, IGroupContextCommandExecutor
    {
        private readonly IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> _createTaskUseCase;
        private readonly IUseCase<FindTaskUseCaseRequest, FindTaskUseCaseResponse> _findTaskUseCase;
        private readonly IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> _startTaskUseCase;
        public GroupContextCommandExecutor(
            IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> createTaskUseCase,
            IUseCase<FindTaskUseCaseRequest, FindTaskUseCaseResponse> findTaskUseCase,
            IUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse> startTaskUseCase
            )
        {
            _createTaskUseCase = createTaskUseCase;
            _findTaskUseCase = findTaskUseCase;
            _startTaskUseCase = startTaskUseCase;
        }

        private async Task ExecuteCreateCommandAsync(Command command)
        {
            // TODO validate command

            var request = new CreateTaskUseCaseRequest(
                GroupId: Context.Current.Id,
                Name: command.parameters
                );

            var response = await _createTaskUseCase.ExecuteAsync(request);
            Context.Current.AddContext(ContextFactory.CreateContext(response.Task));
        }

        private async Task ExecuteOpenCommandAsync(Command command)
        {
            var request = new FindTaskUseCaseRequest(
                Id: ConvertCommandParametersToInt(command),
                Name: command.parameters
                );

            var response = await _findTaskUseCase.ExecuteAsync(request);
            AddTaskToContext(response.Task);
        }

        private async Task ExecuteStartCommandAsync(Command command)
        {
            var request = new StartTaskUseCaseRequest(
                Id: ConvertCommandParametersToInt(command),
                Name: command.parameters
                );
            var response = await _startTaskUseCase.ExecuteAsync(request);
            AddTaskToContext(response.Task);
        }

        private void AddTaskToContext(TaskDto? task)
        {
            if (task != null)
            {
                Context.Current.AddContext(ContextFactory.CreateContext(task));
            }
            else
            {
                // TODO show error
            }
        }

        private void ShowStub()
        {
            System.Console.WriteLine("Unsupported command.");
        }
    }
}

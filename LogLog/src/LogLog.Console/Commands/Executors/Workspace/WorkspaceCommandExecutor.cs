using LogLog.UseCases;
using LogLog.UseCases.Dto;
using LogLog.UseCases.Groups.Create;
using LogLog.UseCases.Groups.GetAll;

namespace LogLog.Console.Commands.Executors.Workspace
{
    public class WorkspaceCommandExecutor : IWorkspaceCommandExecutor
    {
        private readonly IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> _createGroupUseCase;
        private readonly IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> _getAllGroupsUseCase;

        public WorkspaceCommandExecutor(
            IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> createGroupUseCase,
            IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> getAllGroupsUseCase
            )
        {
            _createGroupUseCase = createGroupUseCase;
            _getAllGroupsUseCase = getAllGroupsUseCase;
        }

        public async Task ExecuteAsync(Command command)
        {
            switch(command.Type)
            {
                case CommandType.Create:
                    await CreateGroup(command);
                    break;

                case CommandType.List:
                    await GetAll(command);
                    break;

                case CommandType.Open:
                    break;
            }
        }

        private async Task CreateGroup(Command command)
        {
            await _createGroupUseCase.ExecuteAsync(new CreateGroupUseCaseRequest(Name: command.parameters!));
        }

        private async Task GetAll(Command command)
        {
            var response = await _getAllGroupsUseCase.ExecuteAsync(new GetAllGroupsUseCaseRequest());

            PrintGroupsInfo(response.Groups ?? new List<GroupDto>());
        }

        private void PrintGroupsInfo(List<GroupDto> groups)
        {
            foreach (var group in groups)
            {
                PrintGroupInfo(group);
            }
        }

        private void PrintGroupInfo(GroupDto group)
        {
            PrintLn($"Id:{group.Id} Name:{group.Name}");
        }

        private void PrintLn(string str)
        {
            System.Console.WriteLine(str);
        }
    }
}

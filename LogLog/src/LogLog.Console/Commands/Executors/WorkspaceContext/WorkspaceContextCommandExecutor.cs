using LogLog.Console.State;
using LogLog.UseCases;
using LogLog.UseCases.Dto;
using LogLog.UseCases.Groups.Create;
using LogLog.UseCases.Groups.Delete;
using LogLog.UseCases.Groups.Find;
using LogLog.UseCases.Groups.GetAll;

namespace LogLog.Console.Commands.Executors.WorkspaceContext
{
    public class WorkspaceContextCommandExecutor : BaseCommandExecutor, IWorkspaceContextCommandExecutor
    {
        private readonly IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> _createGroupUseCase;
        private readonly IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> _getAllGroupsUseCase;
        private readonly IUseCase<FindGroupUseCaseRequest, FindGroupUseCaseResponse> _findGroupUseCase;
        private readonly IUseCase<DeleteGroupUseCaseRequest, DeleteGroupUseCaseResponse> _deleteGroupUseCase;

        public WorkspaceContextCommandExecutor(
            IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse> createGroupUseCase,
            IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse> getAllGroupsUseCase,
            IUseCase<FindGroupUseCaseRequest, FindGroupUseCaseResponse> findGroupUseCase,
            IUseCase<DeleteGroupUseCaseRequest, DeleteGroupUseCaseResponse> deleteGroupUseCase
            )
        {
            _createGroupUseCase = createGroupUseCase;
            _getAllGroupsUseCase = getAllGroupsUseCase;
            _findGroupUseCase = findGroupUseCase;
            _deleteGroupUseCase = deleteGroupUseCase;
        }

        private async Task ExecuteCreateCommand(Command command)
        {
            var response = await _createGroupUseCase.ExecuteAsync(new CreateGroupUseCaseRequest(Name: command.parameters!));

            AddGroupToContext(response.Group);
        }

        private async Task ExecuteListCommand(Command command)
        {
            var response = await _getAllGroupsUseCase.ExecuteAsync(new GetAllGroupsUseCaseRequest());

            PrintGroupsInfo(response.Groups ?? new List<GroupDto>());
        }

        private async Task ExecuteOpenCommand(Command command)
        {
            var groupId = ConvertCommandParametersToInt(command);
            var response = await _findGroupUseCase.ExecuteAsync(new FindGroupUseCaseRequest(groupId, command.parameters));
            AddGroupToContext(response.Group);
        }

        private async Task ExecuteDeleteCommand(Command command)
        {
            var groupId = ConvertCommandParametersToInt(command);
            if (groupId.HasValue)
            {
                var response = await _deleteGroupUseCase.ExecuteAsync(new DeleteGroupUseCaseRequest(groupId.Value));
            }
            else
            {
                // TODO show error
            }
            
        }

        private void AddGroupToContext(GroupDto? group)
        {
            if (group != null)
            {
                Context.Current.AddContext(ContextFactory.CreateContext(group));
            }
            else
            {
                // TODO show error
            }
        }




        #region Print

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

        #endregion
    }
}

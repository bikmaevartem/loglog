using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Groups.Create
{
    public class CreateGroupUseCase : BaseGroupsUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public CreateGroupUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public override async Task<CreateGroupUseCaseResponse> ExecuteAsync(CreateGroupUseCaseRequest request)
        {
            var groupEntity = new GroupEntity(name: request.Name, description: request.Description);

            groupEntity = await _groupsRepository.AddAsync(groupEntity);

            #pragma warning disable CS8604
            return new CreateGroupUseCaseResponse(ConvertEntityToDto(groupEntity));
            #pragma warning restore CS8604
        }
    }
}

using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Groups.Create
{
    public class CreateGroupUseCase : IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public CreateGroupUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public async Task<CreateGroupUseCaseResponse> ExecuteAsync(CreateGroupUseCaseRequest request)
        {
            var groupEntity = new GroupEntity(name: request.Name, description: request.Description);

            var newGroupEntity = await _groupsRepository.AddAsync(groupEntity);

            var newGroupDto = new GroupDto(
                Id: newGroupEntity.Id,
                Name: newGroupEntity.Name,
                Description: newGroupEntity.Description,
                Created: newGroupEntity.Created,
                Updated: newGroupEntity.Updated
                );

            return new CreateGroupUseCaseResponse(newGroupDto);
        }
    }
}

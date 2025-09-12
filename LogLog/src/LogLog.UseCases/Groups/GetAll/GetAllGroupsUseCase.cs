using LogLog.Domain.Interfaces.Repositories;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Groups.GetAll
{
    public class GetAllGroupsUseCase : IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public GetAllGroupsUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public async Task<GetAllGroupsUseCaseResponse> ExecuteAsync(GetAllGroupsUseCaseRequest request)
        {
            var groupsEntitiesList = await _groupsRepository.GetAllAsync();

            var groupsDtoList = groupsEntitiesList.Select(g => new GroupDto(
                Id: g.Id,
                Name: g.Name,
                Description: g.Description,
                Created: g.Created,
                Updated: g.Updated
                )).ToList();

            return new GetAllGroupsUseCaseResponse(groupsDtoList);
        }
    }
}

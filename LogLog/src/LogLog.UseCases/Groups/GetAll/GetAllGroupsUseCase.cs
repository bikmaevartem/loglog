using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Groups.GetAll
{
    public class GetAllGroupsUseCase : BaseGroupsUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public GetAllGroupsUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public override async Task<GetAllGroupsUseCaseResponse> ExecuteAsync(GetAllGroupsUseCaseRequest request)
        {
            var groupsEntitiesList = await _groupsRepository.GetAllAsync();

            var groupsDtoList = groupsEntitiesList.Select(g => ConvertEntityToDto(g)).ToList();

            return new GetAllGroupsUseCaseResponse(groupsDtoList);
        }
    }
}

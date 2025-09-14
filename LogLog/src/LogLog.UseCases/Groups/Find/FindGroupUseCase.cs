using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Groups.Find
{
    public class FindGroupUseCase : BaseGroupUseCase<FindGroupUseCaseRequest, FindGroupUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public FindGroupUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public override async Task<FindGroupUseCaseResponse> ExecuteAsync(FindGroupUseCaseRequest request)
        {
            var groupEntity = request.Id.HasValue
                ? await _groupsRepository.FindByIdAsync(request.Id.Value)
                : !string.IsNullOrEmpty(request.Name)
                    ? await _groupsRepository.FindByNameAsync(request.Name)
                    : null;

            return new FindGroupUseCaseResponse(ConvertEntityToDto(groupEntity));
        }
    }
}

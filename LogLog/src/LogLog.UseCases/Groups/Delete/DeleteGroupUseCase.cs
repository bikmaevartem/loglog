using LogLog.Domain.Interfaces.Repositories;

namespace LogLog.UseCases.Groups.Delete
{
    public class DeleteGroupUseCase : BaseGroupUseCase<DeleteGroupUseCaseRequest, DeleteGroupUseCaseResponse>
    {
        private readonly IGroupsRepository _groupsRepository;

        public DeleteGroupUseCase(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public async override Task<DeleteGroupUseCaseResponse> ExecuteAsync(DeleteGroupUseCaseRequest request)
        {
            var group = await _groupsRepository.FindByIdAsync(request.Id);
            
            if (group != null)
            {
                await _groupsRepository.DeleteAsync(request.Id);
            }

            return new DeleteGroupUseCaseResponse(ConvertEntityToDto(group));
        }
    }
}

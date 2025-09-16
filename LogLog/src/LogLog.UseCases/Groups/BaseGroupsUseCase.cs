using LogLog.Domain.Entities;
using LogLog.UseCases.Dto;

namespace LogLog.UseCases.Groups
{
    public abstract class BaseGroupsUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
    {
        public abstract Task<TResponse> ExecuteAsync(TRequest request);

        protected GroupDto? ConvertEntityToDto(GroupEntity? entity)
        {
            var dto = entity != null
                ? new GroupDto(
                        Id: entity.Id,
                        Name: entity.Name,
                        Description: entity.Description,
                        Created: entity.Created,
                        Updated: entity.Updated
                    )
                : null;

            return dto;
        }
    }
}

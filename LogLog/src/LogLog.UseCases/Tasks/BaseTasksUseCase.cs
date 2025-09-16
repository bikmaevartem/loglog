using LogLog.Domain.Entities;
using LogLog.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogLog.UseCases.Tasks
{
    public abstract class BaseTasksUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
    {
        public abstract Task<TResponse> ExecuteAsync(TRequest request);

        protected TaskDto? ConvertEntityToDto(TaskEntity? entity)
        {
            var taskDto = entity != null
                ? new TaskDto(
                    Id: entity.Id,
                    Name: entity.Name,
                    Description: entity.Description,
                    Created: entity.Created,
                    Updated: entity.Updated
                    )
                : null;

            return taskDto;
        }
    }
}

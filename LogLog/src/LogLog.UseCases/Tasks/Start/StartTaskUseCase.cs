using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.Time;

namespace LogLog.UseCases.Tasks.Start
{
    public class StartTaskUseCase : BaseTasksUseCase<StartTaskUseCaseRequest, StartTaskUseCaseResponse>
    {

        private readonly ITasksRepository _tasksRepository;

        public StartTaskUseCase(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public override async Task<StartTaskUseCaseResponse> ExecuteAsync(StartTaskUseCaseRequest request)
        {
            var taskEntity = await FindTaskAsync(request);

            if (taskEntity != null)
            {
                await StartTaskAsync(taskEntity);
            }

            return new StartTaskUseCaseResponse(ConvertEntityToDto(taskEntity));
        }

        private async Task StartTaskAsync(TaskEntity taskEntity)
        {
            var hiddenSubtaskEntity = FindHiddenSubTask(taskEntity);
            if (hiddenSubtaskEntity == null)
            {
                hiddenSubtaskEntity = CreateHiddenSubTask(taskEntity);
                taskEntity.SubTasks.Add(hiddenSubtaskEntity);
            }

            var activePeriod = FindActivePeriod(hiddenSubtaskEntity);
            if (activePeriod == null)
            {
                activePeriod = CreateActivePeriod(hiddenSubtaskEntity);
                hiddenSubtaskEntity.Periods.Add(activePeriod);
            }

            await _tasksRepository.UpdateAsync(taskEntity);
        }

        private async Task<TaskEntity?> FindTaskAsync(StartTaskUseCaseRequest request)
        {
            if (request.Id.HasValue)
            {
                return await _tasksRepository.FindByIdIncludeChildrenAsync(request.Id.Value);
            }

            return await _tasksRepository.FindByNameIncludeChildrenAsync(request.Name);
        }

        private SubTaskEntity? FindHiddenSubTask(TaskEntity taskEntity)
        {
            return (taskEntity.SubTasks ?? new List<SubTaskEntity>())
                .FirstOrDefault(st => st.IsHidden);
        }

        private SubTaskEntity CreateHiddenSubTask(TaskEntity taskEntity)
        {
            var subTask = new SubTaskEntity()
            {
                Name = string.Empty,
                IsHidden = true,
                TaskId = taskEntity.Id,
                Task = taskEntity,
                Created = TimeService.Now,
                Updated = TimeService.Now,
                Periods = new List<PeriodEntity>()
            };

            return subTask;
        }

        private PeriodEntity? FindActivePeriod(SubTaskEntity subTaskEntity)
        {
            return subTaskEntity.Periods.FirstOrDefault(p => p.StopTime == null);
        }

        private PeriodEntity CreateActivePeriod(SubTaskEntity subTaskEntity)
        {
            return new PeriodEntity()
            {
                StartTime = TimeService.Now,
                SubTask = subTaskEntity,
            };
        }

        private async Task UpdateTaskAsync(TaskEntity task)
        {
            await _tasksRepository.UpdateAsync(task);
        }
    }
}

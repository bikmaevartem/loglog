using LogLog.UseCases.Dto;

namespace LogLog.Console.Context
{
    public static class ContextFactory    {
        public static IContext CreateContext(ContextType type)
        {
            return new Context(type);
        }

        public static IContext CreateContext(GroupDto group)
        {
            return new Context(ContextType.Group, group.Id, group.Name);
        }

        public static IContext CreateContext(TaskDto task)
        {
            return new Context(ContextType.Task, task.Id, task.Name);
        }

        public static IContext CreateContext(SubTaskDto subTask)
        {
            return new Context(ContextType.Subtask, subTask.Id, subTask.Name);
        }

        public static IContext CreateContext(PeriodDto period)
        {
            return new Context(ContextType.Period, period.Id, string.Empty);
        }
    }
}

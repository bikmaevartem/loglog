namespace LogLog.Domain.Entities
{
    public class TaskEntity : BaseTaskEntity
    {
        public bool IsCompleted { get; set; }

        public List<SubTask> SubTasks { get; set; } = new();
    }
}

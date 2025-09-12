namespace LogLog.Domain.Entities
{
    public class TaskEntity : BaseTaskEntity
    {
        public int GroupId { get; set; }

        public GroupEntity Group { get; set; } = null!;

        public bool IsExecuting { get; set; }

        public bool IsCompleted { get; set; }

        public List<SubTaskEntity> SubTasks { get; set; } = new();
    }
}

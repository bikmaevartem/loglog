namespace LogLog.Domain.Entities
{
    public class TaskEntity : BaseTaskEntity
    {

        public TaskEntity(int groupId, string name, string? description)
        {
            GroupId = groupId;
            Name = name;
            Description = description;
            Created = DateTimeOffset.Now;
            Updated = DateTimeOffset.Now;
        }

        public int GroupId { get; set; }

        public GroupEntity Group { get; set; } = null!;

        public List<SubTaskEntity> SubTasks { get; set; } = new();
    }
}

namespace LogLog.Domain.Entities
{
    public class GroupEntity : BaseTaskEntity
    {
        public GroupEntity(string name, string? description)
        {
            Name = name;
            Description = description;
            Created = DateTimeOffset.Now;
            Updated = DateTimeOffset.Now;
        }

        public List<TaskEntity> Tasks { get; set; } = new();
    }
}

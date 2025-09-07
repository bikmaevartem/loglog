namespace LogLog.Domain.Entities
{
    public class GroupEntity : BaseTaskEntity
    {
        public GroupEntity(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}

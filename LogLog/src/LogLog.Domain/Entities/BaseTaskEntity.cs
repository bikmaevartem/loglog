namespace LogLog.Domain.Entities
{
    public abstract class BaseTaskEntity : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset Created {  get; set; }

        public DateTimeOffset Updated {  get; set; }
    }
}

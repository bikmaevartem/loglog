namespace LogLog.Domain.Entities
{
    public class SubTaskEntity : BaseTaskEntity
    {
        public int TaskId { get; set; }

        public bool IsHidden { get; set; }

        public List<PeriodEntity> Periods { get; set; } = new();
    }
}

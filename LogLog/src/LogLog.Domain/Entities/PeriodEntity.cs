namespace LogLog.Domain.Entities
{
    public class PeriodEntity : BaseEntity
    {
        public int SubTaskId { get; set; }

        public DateTimeOffset StartTime { get; set; }
        
        public DateTimeOffset StopTime { get; set; }

        public int TotalMinuts { get; set; }

    }
}

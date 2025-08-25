namespace LogLog.UseCases.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsExecuting { get; set; }

        public bool IsCompleted { get; set; }
    }
}

namespace ToDoTasks.Core.DTOs
{
    public class ToDoTaskDto
    {
        public int Id { get; set; }

        public int IdCategory { get; set; }

        public string Description { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string StartDateTime { get; set; } = null!;

        public string EndDateTime { get; set; } = null!;

        public string Time { get; set; } = null!;
    }
}

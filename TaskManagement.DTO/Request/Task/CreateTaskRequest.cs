namespace TaskManagement.DTO.Request.Task
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedById { get; set; }
        public int AssignedToId { get; set; }
    }
}

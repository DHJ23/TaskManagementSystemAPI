namespace TaskManagement.DTO.Request.Task
{
    public class UpdateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedToId { get; set; }
    }
}

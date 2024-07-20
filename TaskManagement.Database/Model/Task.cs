using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Database.Model
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Pending, In Progress, Completed
        public DateTime DueDate { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public int AssignedToId { get; set; }
        public User AssignedTo { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Database.Model
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string Content { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}

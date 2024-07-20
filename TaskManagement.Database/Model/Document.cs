using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Database.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string FilePath { get; set; }
        public int UploadedById { get; set; }
        public User UploadedBy { get; set; }
    }
}

namespace TaskManagement.DTO.Response.Task
{
    public class ListTaskResponse
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        public int CreatedById { get; set; }
        public string CreatedName { get; set; }

        public int AssignedToId { get; set; }
        public string AssignedName { get; set; }

        public List<Note> Notes { get; set; }

        public List<Document> Documents { get; set; }

    }

    public class Document
    {
        public int DocumentId { get; set; }

        public string FilePath { get; set; }

        public int UploadedById { get; set; }
    }

    public class Note
    {
        public int NoteId { get; set; }

        public string Content { get; set; }

        public int CreatedById { get; set; }
    }
}

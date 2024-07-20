namespace TaskManagement.DTO
{
    public class Error
    {
        public Error()
        {
        }
        public Error(string description, string detailedMessage, string field = "")
        {
            Field = field;
            Description = description;
            DetailedMessage = detailedMessage;
        }
        public string Field { get; set; }
        public string Description { get; set; }
        public string DetailedMessage { get; set; }
    }
}

namespace TaskManagement.DTO
{
    public class ValidationResponse
    {
        public ValidationResponse()
        {
            Errors = new();
        }
        public bool IsValid { get; set; } = true;
        public List<Error> Errors { get; set; }
    }
}

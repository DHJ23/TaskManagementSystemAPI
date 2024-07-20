namespace TaskManagement.DTO
{
    public class ListRequest
    {
        public int Limit { get; set; } = Constants.DEFAULT_LIMIT;
        public int Offset { get; set; } = Constants.DEFAULT_OFFSET;
        public string Filter { get; set; } = "";
        public string SortColumn { get; set; }
        public string SortOrder { get; set; } = Constants.DEFAULT_SORTORDER;
    }
}

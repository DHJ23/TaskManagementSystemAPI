using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.DTO
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Errors = new List<Error>();
        }
        public T Result { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<Error> Errors { get; set; }
        public int Count { get; set; } = 0;
    }
}

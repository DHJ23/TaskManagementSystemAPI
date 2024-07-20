using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;
using TaskManagement.DTO;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Response.Task;

namespace TaskManagement.Service.IServices
{
    public interface ITaskService
    {
        Task<string> CreateTask(CreateTaskRequest request);

        Task<List<ListTaskResponse>> ListTask(ListRequest request);
        Task<ListTaskResponse> GetTaskById(int id);
        System.Threading.Tasks.Task UpdateTask(UpdateTaskRequest request, int id);
        Task DeleteTask(int id);
        Task CompleteTask(int id);
    }
}

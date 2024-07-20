using TaskManagement.DTO;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Response.Task;
using TaskManagement.DTO.Response.User;

namespace TaskManagement.Repository.IRepository
{
    public interface ITaskRepository
    {
        Task<string> CreateTask(CreateTaskRequest request);
        Task<List<ListTaskResponse>> ListTask(ListRequest request);
        Task<ListTaskResponse> GetTaskById(int id);
        Task DeleteTask(int id);
        System.Threading.Tasks.Task UpdateTask(UpdateTaskRequest request, int id);
        Task CompleteTask(int id);
    }
}

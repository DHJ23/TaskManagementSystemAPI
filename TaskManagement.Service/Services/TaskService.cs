using TaskManagement.DTO;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Response.Task;
using TaskManagement.DTO.Response.User;
using TaskManagement.Repository.IRepository;
using TaskManagement.Service.IServices;

namespace TaskManagement.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CompleteTask(int id)
        {
           await _taskRepository.CompleteTask(id);
        }

        public async Task<string> CreateTask(CreateTaskRequest request)
        {
           return await _taskRepository.CreateTask(request);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }

        public async Task<ListTaskResponse> GetTaskById(int id)
        {
            return await _taskRepository.GetTaskById(id);   
        }

        public async Task<List<ListTaskResponse>> ListTask(ListRequest request)
        {
            return await _taskRepository.ListTask(request);
        }

        public async System.Threading.Tasks.Task UpdateTask(UpdateTaskRequest request, int id)
        {
            await _taskRepository.UpdateTask(request,id);
        }
    }
}

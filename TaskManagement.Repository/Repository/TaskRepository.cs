using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Database;
using TaskManagement.DTO;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Response.Task;
using TaskManagement.Repository.IRepository;

namespace TaskManagement.Repository.Repository
{
    public class TaskRepository(TaskManagementContext _context, IMapper _mapper) : ITaskRepository
    {
        public async System.Threading.Tasks.Task CompleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            task.Status = "Completed";
            await _context.SaveChangesAsync();
        }

        public async Task<string> CreateTask(CreateTaskRequest request)
        {
            var task = _mapper.Map<TaskManagement.Database.Model.Task>(request);
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.TaskId.ToString();
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<ListTaskResponse> GetTaskById(int id)
        {
            return _mapper.Map<ListTaskResponse>(await _context.Tasks
            .Include(t => t.CreatedBy)
            .Include(t => t.AssignedTo)
            .Include(t => t.Notes)
            .Include(t => t.Documents)
            .FirstOrDefaultAsync(t => t.TaskId == id));
        }

        public async Task<List<ListTaskResponse>> ListTask(ListRequest request)
        {
            return _mapper.Map<List<ListTaskResponse>>(await _context.Tasks
            .Include(t => t.CreatedBy)
            .Include(t => t.AssignedTo)
            .Include(t => t.Notes)
            .Include(t => t.Documents)
            .ToListAsync());
        }

        public async System.Threading.Tasks.Task UpdateTask(UpdateTaskRequest request, int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _mapper.Map(request, task);
            await _context.SaveChangesAsync();
        }
    }
}

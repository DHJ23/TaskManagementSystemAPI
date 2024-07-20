using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Response.Task;
using TaskManagement.Service.IServices;
using TaskManagemnet.API.Extension;

namespace TaskManagemnet.API.Controllers
{
    [Route("task")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IValidator<CreateTaskRequest> _createTaskRequestValidators;
        private readonly ITaskService _taskService;
        private readonly IValidator<ListRequest> _listRequestValidator;

        public TasksController(IValidator<CreateTaskRequest> createTaskRequestValidators, ITaskService taskService, IValidator<ListRequest> listRequestValidator)
        {
            _createTaskRequestValidators = createTaskRequestValidators;
            _taskService = taskService;
            _listRequestValidator = listRequestValidator;
        }

        [HttpGet]
        public async Task<IActionResult> ListTask([FromQuery] ListRequest request)
        {
            var validateResult = await _listRequestValidator.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationFailedResponseMapper.MapToValidationError(validateResult);
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse<string> { Message = Constants.ValidationFailMessage, Errors = validationErrors });
            }
            var result = await _taskService.ListTask(request).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<List<ListTaskResponse>> { Message = Constants.Success, Result = result });
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            var validateResult = await _createTaskRequestValidators.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationFailedResponseMapper.MapToValidationError(validateResult);
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse<string> { Message = Constants.ValidationFailMessage, Errors = validationErrors });
            }
            var result = await _taskService.CreateTask(request);
            return StatusCode(StatusCodes.Status201Created, new BaseResponse<string> { Result = result, Message = string.Format(Constants.CreateSuccess) });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var result = await _taskService.GetTaskById(id).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<ListTaskResponse> { Message = Constants.Success, Result = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequest request,int id)
        {
            await _taskService.UpdateTask(request,id).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<string> { Message = Constants.Success });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<string> { Message = Constants.Success });
        }

        [HttpPut("{id}/complete-task")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            await _taskService.CompleteTask(id).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<string> { Message = Constants.Success });
        }
    }
}

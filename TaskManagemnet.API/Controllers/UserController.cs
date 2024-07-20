using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;
using TaskManagement.Service.IServices;
using TaskManagemnet.API.Extension;

namespace TaskManagemnet.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<CreateUserRequest> _createUserRequestValidators;
        private readonly IUserService _userServices;
        private readonly IValidator<ListRequest> _listRequestValidator;

        public UserController(IValidator<CreateUserRequest> createUserRequestValidators, IUserService userServices, IValidator<ListRequest> listRequestValidator)
        {
            _createUserRequestValidators = createUserRequestValidators;
            _userServices = userServices;
            _listRequestValidator = listRequestValidator;
        }

        [HttpGet]
        public async Task<IActionResult> ListUser([FromQuery] ListRequest request)
        {
            var validateResult = await _listRequestValidator.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationFailedResponseMapper.MapToValidationError(validateResult);
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse<string> { Message = Constants.ValidationFailMessage, Errors = validationErrors });
            }
            var result = await _userServices.ListUser(request).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status200OK, new BaseResponse<List<ListUserResponse>> { Message = Constants.ValidationFailMessage, Result = result });
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var validateResult = await _createUserRequestValidators.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationFailedResponseMapper.MapToValidationError(validateResult);
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse<string> { Message = Constants.ValidationFailMessage, Errors = validationErrors });
            }
            var validate = await _userServices.ValidateCreateUser(request);
            if (validate.IsValid)
            {
                var result = await _userServices.CreateUser(request);
                return StatusCode(StatusCodes.Status201Created, new BaseResponse<string> { Result = result, Message = string.Format(Constants.CreateSuccess) });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse<string> { Message = Constants.ValidationFailMessage, Errors = validate.Errors });
        }
    }
}

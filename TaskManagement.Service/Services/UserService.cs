using TaskManagement.DTO;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;
using TaskManagement.Repository.IRepository;
using TaskManagement.Service.IServices;

namespace TaskManagement.Service.Services
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Service
        public async Task<string> CreateUser(CreateUserRequest request)
        {
            return await _userRepository.CreateUser(request);
        }

        public async Task<List<ListUserResponse>> ListUser(ListRequest request)
        {
            return await _userRepository.ListUser(request);
        }
        #endregion

        #region Validation
        public async Task<ValidationResponse> ValidateCreateUser(CreateUserRequest request)
        {
            ValidationResponse validationResult = new();

            if (await _userRepository.IsEmailExist(request.Email))
            {
                validationResult.Errors.Add(new Error
                {
                    Description = string.Format(Constants.AlreadyExists, "Email", request.Email),
                    DetailedMessage = "",
                    Field = "Email"
                });
            }
            if (validationResult.Errors.Any())
            {
                validationResult.IsValid = validationResult.Errors?.Count == 0;

            }
            return validationResult;
        }
        #endregion
    }
}

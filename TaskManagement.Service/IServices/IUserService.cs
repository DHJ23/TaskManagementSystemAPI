using TaskManagement.DTO;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;

namespace TaskManagement.Service.IServices
{
    public interface IUserService
    {
        #region Service
        Task<string> CreateUser(CreateUserRequest request);
        Task<List<ListUserResponse>> ListUser(ListRequest request);
        #endregion

        #region Validation
        Task<ValidationResponse> ValidateCreateUser(CreateUserRequest request);
        #endregion
    }
}

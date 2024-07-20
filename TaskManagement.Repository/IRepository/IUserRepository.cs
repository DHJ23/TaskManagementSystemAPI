using TaskManagement.DTO;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;

namespace TaskManagement.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<string> CreateUser(CreateUserRequest request);

        Task<List<ListUserResponse>> ListUser(ListRequest request);

        Task<bool> IsEmailExist(string email);
    }
}

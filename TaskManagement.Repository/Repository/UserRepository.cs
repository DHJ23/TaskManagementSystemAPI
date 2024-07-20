using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Database;
using TaskManagement.Database.Model;
using TaskManagement.DTO;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.User;
using TaskManagement.Repository.IRepository;

namespace TaskManagement.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementContext _taskManagementContext;
        private readonly IMapper _mapper;

        public UserRepository(TaskManagementContext taskManagementContext, IMapper mapper)
        {
            _taskManagementContext = taskManagementContext;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _taskManagementContext.Users.AddAsync(user);
            await _taskManagementContext.SaveChangesAsync();
            return user.UserId.ToString();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _taskManagementContext.Users.AnyAsync(x => x.Email == email).ConfigureAwait(false);
        }

        public async Task<List<ListUserResponse>> ListUser(ListRequest request)
        {
            return _mapper.Map<List<ListUserResponse>>(await _taskManagementContext.Users.ToListAsync());
        }
    }
}

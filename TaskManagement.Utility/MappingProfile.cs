using AutoMapper;
using TaskManagement.Database.Model;
using TaskManagement.DTO.Request.Task;
using TaskManagement.DTO.Request.User;
using TaskManagement.DTO.Response.Task;
using TaskManagement.DTO.Response.User;
namespace TaskManagement.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, ListUserResponse>();
            CreateMap<CreateTaskRequest, TaskManagement.Database.Model.Task>();
            CreateMap<TaskManagement.Database.Model.Task, ListTaskResponse>()
               .ForMember(dest => dest.CreatedName, opt => opt.MapFrom(src => src.CreatedBy.Name))
            .ForMember(dest => dest.AssignedName, opt => opt.MapFrom(src => src.AssignedTo.Name))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents));
            CreateMap<UpdateTaskRequest, TaskManagement.Database.Model.Task>();
        }
    }
}

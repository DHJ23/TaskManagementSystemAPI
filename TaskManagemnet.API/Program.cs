using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagement.Database;
using TaskManagement.Service.Attributes;
using TaskManagement.Utility;
using TaskManagemnet.API.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

#region DataBase
// Add services to the container.
builder.Services.AddDbContext<TaskManagementContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
#endregion

#region FluentValidation
builder.Services.AddValidatorsFromAssemblies(new[] { typeof(CreateUserRequestValidator).Assembly }, ServiceLifetime.Singleton);
#endregion

#region Service
builder.Services.RegisterAutoMapper();
#endregion

#region Dependency Injection            
builder.Services.RegisterRepository(Assembly.Load("TaskManagement.Repository"));
builder.Services.RegisterServices(Assembly.Load("TaskManagement.Service"), serviceType =>
{
    ServiceLifetimeAttribute attribute = serviceType.GetCustomAttribute<ServiceLifetimeAttribute>();
    ServiceLifetime lifetime = attribute == null ? ServiceLifetime.Scoped : attribute.LifeTime;
    return lifetime;
});
#endregion



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

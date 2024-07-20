using Microsoft.Extensions.DependencyInjection;

namespace TaskManagement.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceLifetimeAttribute : Attribute
    {
        public ServiceLifetime LifeTime { get; set; }

        public ServiceLifetimeAttribute(ServiceLifetime serviceLifetime)
        {
            LifeTime = serviceLifetime;
        }
    }
}

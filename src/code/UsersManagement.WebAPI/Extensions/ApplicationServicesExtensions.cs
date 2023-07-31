using UsersManagement.Application.Services;
using UsersManagement.Core.Interfaces.IRepository;
using UsersManagement.Core.Interfaces;
using UsersManagement.Infrastracture.Data;
using UsersManagement.Infrastracture.Repositories;

namespace UsersManagement.WebAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

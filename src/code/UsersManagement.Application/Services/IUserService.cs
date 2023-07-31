using UsersManagement.Core.Entities;

namespace UsersManagement.Application.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<int> DeleteAsync(int id);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}

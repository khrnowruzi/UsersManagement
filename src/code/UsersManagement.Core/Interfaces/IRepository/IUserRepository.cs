using UsersManagement.Core.Entities;

namespace UsersManagement.Core.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<int> DeleteAsync(int id);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
    }
}

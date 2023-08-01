using UsersManagement.Core.Entities;
using UsersManagement.Core.Interfaces;
using UsersManagement.Core.Interfaces.IRepository;

namespace UsersManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            var addedUser = await _userRepository.CreateAsync(user);
            await _unitOfWork.Complete();
            return addedUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = await _userRepository.UpdateAsync(user);
            await _unitOfWork.Complete();
            return updatedUser;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await _userRepository.DeleteAsync(id);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UsersManagement.Core.Entities;
using UsersManagement.Core.Interfaces.IRepository;
using UsersManagement.Infrastracture.Data;

namespace UsersManagement.Infrastracture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            var addedUser = await _dbContext.Users.AddAsync(user);
            return addedUser.Entity;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userFromDb != null)
            {
                userFromDb.FirstName = user.FirstName;
                userFromDb.LastName = user.LastName;
                userFromDb.Birthday = user.Birthday;

                _dbContext.Users.Update(user);
                return userFromDb;
            }
            return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (userFromDb != null)
            {
                _dbContext.Users.Remove(userFromDb);
                return 1;
            }
            return 0;
        }

        public async Task<User> Get(int id)
        {
            var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return userFromDb ?? new User();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}

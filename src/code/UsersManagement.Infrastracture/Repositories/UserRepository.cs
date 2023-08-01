using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
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
            user.CreateDate = DateTime.Now;
            var addedUser = await _dbContext.Users.AddAsync(user);
            return addedUser.Entity;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userFromDb = await _dbContext.Users.FindAsync(user.Id);
            if (userFromDb == null)
                throw new Exception("User not found!");
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.Birthday = user.Birthday;
            _dbContext.Users.Update(userFromDb);
            return userFromDb;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var userFromDb = await _dbContext.Users.FindAsync(id);
            if (userFromDb == null)
                throw new Exception("User not found!");
            _dbContext.Users.Remove(userFromDb);
            return 1;
        }

        public async Task<User> GetAsync(int id)
        {
            var userFromDb = await _dbContext.Users.FindAsync(id);
            if (userFromDb == null)
                throw new Exception("User not found!");
            return userFromDb;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }
    }
}

using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Service.Contracts;

namespace ServerLibrary.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetOrCreateUserAsync(string nickname)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
            if (user == null)
            {
                user = new User { Nickname = nickname };
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            return user;
        }
    }
}

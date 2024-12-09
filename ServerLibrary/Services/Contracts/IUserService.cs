using BaseLibrary.Entities;

namespace ServerLibrary.Service.Contracts
{
    public interface IUserService
    {
        Task<User> GetOrCreateUserAsync(string nickname);
    }
}

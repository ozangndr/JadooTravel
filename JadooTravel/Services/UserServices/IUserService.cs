using JadooTravel.Entities;

namespace JadooTravel.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(string username, string password);
        Task<bool> LoginAsync(string username, string password);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}

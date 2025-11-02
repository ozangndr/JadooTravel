using JadooTravel.Entities;
using Microsoft.CodeAnalysis.Scripting;
using MongoDB.Driver;
using BCrypt.Net;

namespace JadooTravel.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("JadooTravelDb");
            _users = database.GetCollection<User>("Users");
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var existingUser = await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
            if (existingUser != null)
                return false;

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            await _users.InsertOneAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}

using Plants.Api.Domain.Entities;

namespace Plants.Api.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> Get(string name);
        public Task Create(User newUser);
        public Task Update(string id, User user);
        public Task Remove(string id);
    }
}

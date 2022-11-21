using Plants.Services.Dtos;

namespace Plants.Api.Services
{
    public interface IUserService
    {
        public  Task<List<User>> GetAllUsers();
        public  Task<User> Get(string id);
        public Task Create(User NewUser);

    }
}

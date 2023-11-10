using Plants.Api.Domain.Dtos;
using Plants.Domain.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IUserService
    {
        public Task<TokenDTO> Login(UserDTO loginUser);
        public Task Create(UserDTO loginUser);
        public Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId);
    }
}


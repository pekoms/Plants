using Plants.Api.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IPlantService
    {
        public Task Create(PlantDTO createPlant, string token);
        public Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId,string token);
        public Task<List<PlantDTO>> GetPlantByPlantId(string plantId, string token);
    }
}

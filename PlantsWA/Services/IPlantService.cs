using Plants.Api.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IPlantService
    {
        public  Task Create(PlantDTO createPlant);
        public Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId);
    }
}

using Plants.Api.Domain.Entities;

namespace Plants.Api.Services
{
    public interface IPlantService
    {
        public Task<List<Plant>> GetAllPlants();
        public Task<Plant> Get(string id);
        public Task<List<Plant>> GetAllPlantsByUserId(string userId);
        public Task Create(Plant newPlant);
        public Task Update(string id, Plant plant);
        public Task Remove(string id);
        

    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plants.Api.Domain.Entities;
using Plants.Infrastructure.DBSettings;

namespace Plants.Api.Services
{
    public class PlantService:IPlantService
    {
        private readonly IMongoCollection<Plant> _plants;

        public PlantService(IOptions<PlantsDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _plants = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Plant>(options.Value.PlantsCollectionName);
        }

        public async Task<List<Plant>> GetAllPlants() =>
            await _plants.Find(_ => true).ToListAsync();
        public async Task<Plant> Get(string id) =>
            await _plants.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task Create(Plant newPlant)=>
            await _plants.InsertOneAsync(newPlant);
        
        public async Task Update(string id, Plant updatePlant) =>
            await _plants.ReplaceOneAsync(m => m.Id == id, updatePlant);
        public async Task Remove(string id) =>
            await _plants.DeleteOneAsync(m => m.Id == id);
    }
}

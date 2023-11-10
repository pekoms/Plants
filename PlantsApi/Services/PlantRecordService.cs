using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plants.Api.Domain.Entities;
using Plants.Infrastructure.DBSettings;

namespace Plants.Api.Services
{
    public class PlantRecordService : IPlantRecordService
    {

        private readonly IMongoCollection<PlantRecord> _plantsRecords;

        public PlantRecordService(IOptions<PlantsDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _plantsRecords = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<PlantRecord>(options.Value.PlantsRecordsCollectionName);
        }

        public async Task<List<PlantRecord>> GetAllPlantRecords() =>
            await _plantsRecords.Find(_ => true).ToListAsync();
        public async Task<PlantRecord> Get(string id) =>
            await _plantsRecords.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task Create(PlantRecord newPlantRecord) =>
            await _plantsRecords.InsertOneAsync(newPlantRecord);
        public async Task Update(string id, PlantRecord updatePlantRecord) =>
            await _plantsRecords.ReplaceOneAsync(m => m.Id == id, updatePlantRecord);
        public async Task Remove(string id) =>
            await _plantsRecords.DeleteOneAsync(m => m.Id == id);

        public async Task<List<PlantRecord>> GetAllPlantRecordsByPlantId(string plantId) =>
           await _plantsRecords.Find(m => m.PlantId == plantId).ToListAsync();

    }
}

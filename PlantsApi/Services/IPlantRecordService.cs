using Plants.Api.Domain.Entities;

namespace Plants.Api.Services
{
    public interface IPlantRecordService
    {
        public Task<List<PlantRecord>> GetAllPlantRecords();
        public Task<List<PlantRecord>> GetAllPlantRecordsByPlantId(string plantId);

        public Task<PlantRecord> Get(string id);
        public Task Create(PlantRecord newPlantRecord);
        public Task Update(string id, PlantRecord plantRecord);
        public Task Remove(string id);
    }
}

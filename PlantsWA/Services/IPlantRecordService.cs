using Plants.Api.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IPlantRecordService
    {
        public Task Create(PlantRecordDTO createPlantRecord,string token);
        public Task Update(PlantRecordDTO createPlantRecord, string token);
        public Task Delete(string plantRecordId,string token);      
        public Task<PlantRecordDTO> Get(string Id,string token);
        public Task<List<PlantRecordDTO>> GetAllPlantsByPlantId(string PlantId, string token);
        public Task<List<PlantRecordDTO>> GetAllPlantsNominated(string UserId, string token);
    }
}

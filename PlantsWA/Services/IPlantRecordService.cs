using Plants.Api.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IPlantRecordService
    {
        public Task Create(PlantRecordDTO createPlantRecord);
        public Task Update(PlantRecordDTO createPlantRecord);
        public Task Delete(string plantRecordId);
        public Task<List<PlantRecordDTO>> GetAllPlantsByPlantId(string PlantId);
        public Task<PlantRecordDTO> Get(string Id);

    }
}

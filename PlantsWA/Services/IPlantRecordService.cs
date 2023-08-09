using Plants.Api.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface IPlantRecordService
    {
        public  Task Create(PlantRecordDTO createPlantRecord);
        public Task Update(PlantRecordDTO createPlantRecord);

        public Task<List<PlantRecordDTO>> GetAllPlantsByPlantId(string PlantId);
    }
}

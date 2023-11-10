using Microsoft.AspNetCore.Components;
using Plants.Api.Domain.Dtos;
using Plants.WA.Services;

namespace Plants.WA.Pages
{
    public partial class NewPlantRecord
    {
        [Inject] private IPlantRecordService IplantServiceRecord { get; set; }



        public async Task CrearPlantRecord(PlantRecordDTO createPlant)
        {
            var response = IplantServiceRecord.Create(createPlant);
        }
    }
}

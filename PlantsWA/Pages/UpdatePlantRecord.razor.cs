using Microsoft.AspNetCore.Components;
using Plants.Api.Domain.Dtos;
using Plants.WA.Services;

namespace Plants.WA.Pages
{
    public partial class UpdatePlantRecord
    {
        [Inject] private IPlantRecordService IplantServiceRecord { get; set; }




        public async Task ActualizaPlantRecord(PlantRecordDTO createPlant,string token)
        {
            var response = IplantServiceRecord.Update(createPlant, token);
        }
    }
}

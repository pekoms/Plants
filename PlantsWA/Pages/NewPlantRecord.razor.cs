using Microsoft.AspNetCore.Components;
using Plants.WA.Services;

namespace Plants.WA.Pages
{
    public partial class NewPlantRecord
    {
        [Inject] private IPlantService IplantService { get; set; }

        public async Task CrearPlantRecord(Object createPlant)
        {
           var response =  IplantService.Create(createPlant);
        }
    }
}

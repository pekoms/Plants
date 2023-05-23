using Microsoft.AspNetCore.Components;
using Plants.Api.Domain.Dtos;
using Plants.WA.Services;

namespace Plants.WA.Pages
{
    public partial class NewPlant
    {
        [Inject] private IPlantService IplantService { get; set; }

        public async Task CrearPlantRecord(PlantDTO createPlant)
        {
           var response =   IplantService.Create(createPlant);
        }
    }
}

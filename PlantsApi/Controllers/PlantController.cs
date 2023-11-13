using Microsoft.AspNetCore.Mvc;
using Plants.Api.Domain.Dtos;
using Plants.Api.Domain.Entities;
using Plants.Api.Infrastructure.TokenValidation;
using Plants.Api.Services;

namespace Plants.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private IPlantService _plantService;
        private IUtilsService _utilsService;

        public PlantController(IPlantService plantService, IUtilsService utilsService)
        {
            _plantService = plantService;
            _utilsService = utilsService;
        }
        
        [AuthorizationAttributeGet("GetAllPlants")]        
        public async Task<ActionResult<List<Plant>>> Get(CancellationToken cancellationToken)
        {
            var users = await _plantService.GetAllPlants();

            return Ok(users);
        }
    
        [AuthorizationAttributeGet("{id}", Name = "GetDetailedPlant")]
        public async Task<ActionResult<Plant>> GetDetailedPlant(string id, CancellationToken cancellationToken)
        {
            var user = await _plantService.Get(id); ;

            return Ok(user);
        }        

        [AuthorizationAttributePost("CreatePlant")]
        public async Task<ActionResult> CreatePlant([FromBody] PlantDTO newPlantDTO, CancellationToken cancellationToken)
        {
            var newPlant = new Plant
            {
                Name = newPlantDTO.Nombre,
                Specie = newPlantDTO.Especie,
                Age = newPlantDTO.Edad,
                OwnerId = newPlantDTO.OwnerId,
                Foto = newPlantDTO.Foto

            };
            await _plantService.Create(newPlant);
            return Ok();
        }
        
        [AuthorizationAttributePut("{id}", Name = "UpdateDetailedPlant")]        
        public async Task<ActionResult> UpdateDetailedPlant(string id, [FromBody] Plant plant, CancellationToken cancellationToken)
        {

            await _plantService.Update(id, plant);

            return Ok(plant);
        }
        
        [AuthorizationAttributeDelete("{id}", Name = "DeleteDetailedPlant")]
        public async Task<ActionResult> Delete(string id)
        {
            await _plantService.Remove(id);

            return Ok();
        }
        
        [AuthorizationAttributeGet("User")]
        public async Task<ActionResult<Plant>> GetDetailedPlantByUserId(string ownerId, CancellationToken cancellationToken)
        {
            var plants = await _plantService.GetAllPlantsByUserId(ownerId); ;

            return Ok(plants);
        }
    }
}

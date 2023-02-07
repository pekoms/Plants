using Microsoft.AspNetCore.Mvc;
using Plants.Api.Domain.Dtos;
using Plants.Api.Domain.Entities;
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

        // GET: UserController
        [HttpGet(Name = "GetAllPlants")]
        public async Task<ActionResult<List<Plant>>> Get(CancellationToken cancellationToken)
        {
            var users = await _plantService.GetAllPlants();

            return Ok(users);
        }

        //GET: UserController/Details/5
        [HttpGet("{id}", Name = "GetDetailedPlant")]
        public async Task<ActionResult<Plant>> GetDetailedPlant(string id, CancellationToken cancellationToken)
        {
            var user = await _plantService.Get(id); ;

            return Ok(user);
        }

        // POST: UserController/Create

        [HttpPost(Name = "CreatePlant")]
        public async Task<ActionResult> CreatePlant([FromForm] PlantDTO newPlantDTO, CancellationToken cancellationToken)
        {
            var newPlant = new Plant { Name = newPlantDTO.Name,
                Specie = newPlantDTO.Specie,
                Age = newPlantDTO.Age,
                Shop = newPlantDTO.Shop,
                Finsert = newPlantDTO.Finsert,
                ContentImage = await _utilsService.GetImageFromFile(newPlantDTO.ContentImage)
        };
            await _plantService.Create(newPlant);
            return Ok(newPlant);
        }

       

        // POST: UserController/Edit/5
        [HttpPut("{id}", Name = "UpdateDetailedPlant")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateDetailedPlant(string id, [FromBody] Plant plant, CancellationToken cancellationToken)
        {   
            
            await _plantService.Update(id, plant);

            return Ok(plant);
        }

        // Delete: UserController/Delete/5
        [HttpDelete("{id}", Name = "DeleteDetailedPlant")]
        public async Task<ActionResult> Delete(string id)
        {
            await _plantService.Remove(id);

            return Ok();
        }
    }
}

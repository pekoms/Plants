using Microsoft.AspNetCore.Mvc;
using Plants.Api.Domain.Dtos;
using Plants.Api.Domain.Entities;
using Plants.Api.Infrastructure.TokenValidation;
using Plants.Api.Services;

namespace Plants.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantRecordController : ControllerBase
    {
        private IPlantRecordService _plantRecordService;

        public PlantRecordController(IPlantRecordService plantRecordService)
        {
            _plantRecordService = plantRecordService;

        }
        
        [AuthorizationAttributeGet("GetAllPlantRecords")]
        public async Task<ActionResult<List<PlantRecord>>> Get(CancellationToken cancellationToken)
        {
            var PlantRecords = await _plantRecordService.GetAllPlantRecords();

            return Ok(PlantRecords);
        }
        
        [AuthorizationAttributeGet("{id}", Name = "GetDetailedPlantRecord")]
        public async Task<ActionResult<PlantRecord>> GetDetailedPlantRecord(string id, CancellationToken cancellationToken)
        {
            var PlantRecord = await _plantRecordService.Get(id); ;

            return Ok(PlantRecord);
        }
       
        [AuthorizationAttributePost("CreatePlantRecord")]
        public async Task<ActionResult> CreatePlantRecord([FromBody] PlantRecordDTO newPlantRecordDTO, CancellationToken cancellationToken)
        {
            var newPlantRecord = new PlantRecord
            {
                PlantId = newPlantRecordDTO.PlantId,
                Observation = newPlantRecordDTO.Observation,
                IsFertilised = newPlantRecordDTO.IsFertilised,
                IsWatered = newPlantRecordDTO.IsWatered,
                ContentImage = newPlantRecordDTO.ContentImage,
                UserId = newPlantRecordDTO.UserId

            };
            await _plantRecordService.Create(newPlantRecord);
            return Ok(newPlantRecord);
        }

        // PUT: PlantRecordController/Edit/5
        [AuthorizationAttributePut("{id}", Name = "UpdateDetailedPlantRecord")]
        public async Task<ActionResult> UpdateDetailedPlantRecord(string id, [FromBody] PlantRecord PlantRecord, CancellationToken cancellationToken)
        {
            await _plantRecordService.Update(id, PlantRecord);

            return Ok(PlantRecord);
        }

        // Delete: PlantRecordController/Delete/5
        [AuthorizationAttributeDelete("{id}", Name = "DeleteDetailedPlantRecord")]
        public async Task<ActionResult> Delete(string id)
        {
            await _plantRecordService.Remove(id);

            return Ok();
        }

        //GET: UserController/Details/5

        [AuthorizationAttributeGet("Plant")]
        public async Task<ActionResult<PlantRecord>> GetDetailedPlantByPlantId(string plantId, CancellationToken cancellationToken)
        {
            var plants = await _plantRecordService.GetAllPlantRecordsByPlantId(plantId); ;

            return Ok(plants);
        }
    }
}

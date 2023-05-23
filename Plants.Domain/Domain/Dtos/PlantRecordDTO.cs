using Microsoft.AspNetCore.Http;

namespace Plants.Api.Domain.Dtos
{
    public class PlantRecordDTO
    {        
        public string Id { get; set; } = Guid.NewGuid().ToString();        
        public string PlantId { get; set; }        
        public bool IsNominated { get; set; }        
        public bool IsWatered { get; set; }        
        public bool WaterQuantity { get; set; }        
        public bool IsTranplanted { get; set; }        
        public bool IsFertilised { get; set; }        
        public bool FertiliserQuantity { get; set; }        
        public string Observation { get; set; } = "";
        public DateTime Finsert { get; set; } = DateTime.UtcNow;       
        public IFormFile? ContentImage { get; set; }
    }
}

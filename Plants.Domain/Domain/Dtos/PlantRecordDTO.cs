using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Plants.Api.Domain.Dtos
{
    public class PlantRecordDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("votes")]
        public int Votes { get; set; }
        [JsonPropertyName("isNominated")]
        public bool IsNominated { get; set; }
        [JsonPropertyName("isWatered")]
        public bool IsWatered { get; set; }   
        [JsonPropertyName("waterQuantity")]
        public bool WaterQuantity { get; set; }
        [JsonPropertyName("isTranplanted")]
        public bool IsTranplanted { get; set; }
        [JsonPropertyName("isFertilised")]
        public bool IsFertilised { get; set; }
        [JsonPropertyName("fertiliserQuantity")]
        public bool FertiliserQuantity { get; set; }
        [JsonPropertyName("observation")]
        public string Observation { get; set; } = "";
        [JsonPropertyName("fInsert")]
        public DateTime Finsert { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("contentImage")]
        public string? ContentImage { get; set; }
    }
}

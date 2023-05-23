using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Plants.Api.Domain.Dtos
{
    public class PlantDTO
    {
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }
        [JsonPropertyName("Especie")]

        public string? Especie { get; set; }
        [JsonPropertyName("Edad")]

        public int Edad { get; set; }
        [JsonPropertyName("Shop")]

        public string? Shop { get; set; }
        [JsonPropertyName("UbicacionCasa")]

        public string? UbicacionCasa { get; set; }
        [JsonPropertyName("FechaLlegadaCasa")]

        public string? FechaLlegadaCasa { get; set; }
        [JsonPropertyName("Foto")]

        public string? Foto { get; set; }

        public string? Familia { get; set; }
        public string? Origen { get; set; }
        public string? Caracteristicas { get; set; }
        public string? Hojas { get; set; }
        public string? Flores { get; set; }
        public string? EpocaFloracion { get; set; }
        public string? Destino { get; set; }
        public string? Adaptacion { get; set; }
        public string? Suelo { get; set; }
        public string? Luminosidad { get; set; }
        public string? ResistenciaFrio { get; set; }
        public string? HumedadAmbiente { get; set; }
        public string? Riego { get; set; }
        public string? Abonos { get; set; }
        public string? Parasitos { get; set; }
        public string? Propagacion { get; set; }
        public string? Cuidados { get; set; }

        public DateTime? Finsert { get; set; }=DateTime.UtcNow;

        public IFormFile? ContentImage { get; set; }
    }
}

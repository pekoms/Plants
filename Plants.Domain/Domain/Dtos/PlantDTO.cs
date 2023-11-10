using System.Text.Json.Serialization;

namespace Plants.Api.Domain.Dtos
{
    public class PlantDTO
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Nombre { get; set; }
        [JsonPropertyName("ownerId")]
        public string? OwnerId { get; set; }
        [JsonPropertyName("especie")]
        public string? Especie { get; set; }
        [JsonPropertyName("edad")]

        public int Edad { get; set; }
        [JsonPropertyName("shop")]

        public string? Shop { get; set; }
        [JsonPropertyName("ubicacionCasa")]

        public string? UbicacionCasa { get; set; }
        [JsonPropertyName("fechaLlegadaCasa")]

        public string? FechaLlegadaCasa { get; set; }
        [JsonPropertyName("foto")]
        public string? Foto { get; set; }

        //public string? Familia { get; set; }
        //public string? Origen { get; set; }
        //public string? Caracteristicas { get; set; }
        //public string? Hojas { get; set; }
        //public string? Flores { get; set; }
        //public string? EpocaFloracion { get; set; }
        //public string? Destino { get; set; }
        //public string? Adaptacion { get; set; }
        //public string? Suelo { get; set; }
        //public string? Luminosidad { get; set; }
        //public string? ResistenciaFrio { get; set; }
        //public string? HumedadAmbiente { get; set; }
        //public string? Riego { get; set; }
        //public string? Abonos { get; set; }
        //public string? Parasitos { get; set; }
        //public string? Propagacion { get; set; }
        public string? Cuidados { get; set; }

        public DateTime? Finsert { get; set; } = DateTime.UtcNow;


    }
}

using Microsoft.AspNetCore.Http;

namespace Plants.Api.Domain.Dtos
{
    public class PlantDTO
    {
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public int Age { get; set; }
        public string? Shop { get; set; }

        private string? UbicacionCasa { get; set; }
        private string? FechaLlegadaCasa { get; set; }
        private string? Foto { get; set; }

        private string? Familia { get; set; }
        private string? Origen { get; set; }
        private string? Caracteristicas { get; set; }
        private string? Hojas { get; set; }
        private string? Flores { get; set; }
        private string? EpocaFloracion { get; set; }
        private string? Destino { get; set; }
        private string? Adaptacion { get; set; }
        private string? Suelo { get; set; }
        private string? Luminosidad { get; set; }
        private string? ResistenciaFrio { get; set; }
        private string? HumedadAmbiente { get; set; }
        private string? Riego { get; set; }
        private string? Abonos { get; set; }
        private string? Parasitos { get; set; }
        private string? Propagacion { get; set; }
        private string? Cuidados { get; set; }

        public DateTime? Finsert { get; set; }=DateTime.UtcNow;
        public IFormFile? ContentImage { get; set; }
    }
}

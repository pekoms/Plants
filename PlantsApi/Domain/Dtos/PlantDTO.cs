namespace Plants.Api.Domain.Dtos
{
    public class PlantDTO
    {
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public int Age { get; set; }
        public string? Shop { get; set; }
        public DateTime? Finsert { get; set; }=DateTime.UtcNow;
        public IFormFile? ContentImage { get; set; }
    }
}

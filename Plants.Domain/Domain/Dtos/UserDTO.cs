using System.Text.Json.Serialization;

namespace Plants.Domain.Domain.Dtos
{
    public class UserDTO
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}

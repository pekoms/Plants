using Microsoft.Extensions.FileProviders;
using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class Plant
    {

        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public int Age { get; set; }
        public string? Shop { get; set; }
        public DateTime? Finsert { get; set; } = DateTime.Now;        
        public string? ContentImage { get; set; }
    }
}

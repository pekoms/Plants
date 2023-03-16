using Microsoft.Extensions.FileProviders;
using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class Plant
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Specie { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int Age { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Shop { get; set; }
        public DateTime? Finsert { get; set; } = DateTime.Now;        
        public string? ContentImage { get; set; }
    }
}

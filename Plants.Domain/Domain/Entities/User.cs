using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class User
    {
        [BsonId]        
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Password { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Email { get; set; }

    }
}

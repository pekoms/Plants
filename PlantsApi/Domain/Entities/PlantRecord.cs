using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class PlantRecord
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string PlantId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsNominated { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsWatered { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public bool WaterQuantity { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsTranplanted { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsFertilised { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public bool FertiliserQuantity { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Observation { get; set; } = "";
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime Finsert { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Binary)]
        public byte[]? ContentImage { get; set; }
    }
}

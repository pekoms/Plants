using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Api.Domain.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Password { get; set; }

    }
}

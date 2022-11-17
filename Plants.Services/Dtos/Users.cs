using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Services.Dtos
{
    internal class Users
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        private Guid Id { get; set; }
        private string? Name { get; set; }
        private string? Password { get; set; }

    }
}

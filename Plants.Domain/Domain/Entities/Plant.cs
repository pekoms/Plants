using Microsoft.Extensions.FileProviders;
using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class Plant
    {

        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string OwnerId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Specie { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int Age { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Shop { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? UbicacionCasa { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? FechaLlegadaCasa { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Foto { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string? Familia { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Origen { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Caracteristicas { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Hojas { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Flores { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? EpocaFloracion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Destino { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Adaptacion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Suelo { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Luminosidad { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? ResistenciaFrio { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? HumedadAmbiente { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Riego { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Abonos { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Parasitos { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Propagacion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? Cuidados { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public DateTime? Finsert { get; set; } = DateTime.Now;
        

    }
}

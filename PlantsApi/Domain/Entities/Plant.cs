using Microsoft.Extensions.FileProviders;
using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Api.Domain.Entities
{
    public class Plant
    {

        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Specie { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int Age { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Shop { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? UbicacionCasa { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? FechaLlegadaCasa { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Foto { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]


        private string? Familia { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Origen { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Caracteristicas { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Hojas { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Flores { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? EpocaFloracion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Destino { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Adaptacion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Suelo { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Luminosidad { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? ResistenciaFrio { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? HumedadAmbiente { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Riego { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Abonos { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Parasitos { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Propagacion { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        private string? Cuidados { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public DateTime? Finsert { get; set; } = DateTime.Now;   
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string? ContentImage { get; set; }
    }
}

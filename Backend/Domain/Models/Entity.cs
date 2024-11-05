using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Entity
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public object Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid EntityId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

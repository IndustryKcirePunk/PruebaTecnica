using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Employee
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public object Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid EmployeeId { get; set; } = Guid.NewGuid();
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid EntityId { get; set; }
        public string FullName { get; set; }
        public string TypeIdentification { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

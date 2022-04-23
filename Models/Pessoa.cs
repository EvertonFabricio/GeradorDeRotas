using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Pessoa
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool Disponivel { get; set; }
    }
}

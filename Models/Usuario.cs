using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
    }
}

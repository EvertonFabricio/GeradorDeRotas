using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Equipe
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Codigo { get; set; }
        public List<Pessoa> Pessoa { get; set; }
        public Cidade Cidade { get; set; }
    }
}

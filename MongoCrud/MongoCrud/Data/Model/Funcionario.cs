using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCrud.Data.Model
{
    public class Funcionario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string nome { get; set; }   
        public int idade { get; set;}
        public int matricula { get; set;}
        public bool ativo { get; set;}

    }
}

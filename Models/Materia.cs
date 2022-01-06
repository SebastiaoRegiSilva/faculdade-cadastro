using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Models
{
    public class Materia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        /// <summary></summary>
        public string Name { get; set; }
        
        /// <summary></summary>
        public string Description { get; set; }
        
    }
}
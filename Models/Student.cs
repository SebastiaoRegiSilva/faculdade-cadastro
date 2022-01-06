using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Models
{
    /// <summary></summary>
    public class Student
    {
        /// <summary>Código de identificação do estudante.</summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        /// <summary></summary>
        public string FirstName { get; set; }
        
        /// <summary></summary>
        public string LastName { get; set; }
        
        /// <summary></summary>
        public string Major { get; set; }
    }
}
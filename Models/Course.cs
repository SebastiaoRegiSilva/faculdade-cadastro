using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Models
{
    /// <summary></summary>
    public class Course
    {
        /// <summary>Código de identificação do curso.</summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        /// <summary></summary>
        public string Name { get; set; }
        
        /// <summary></summary>
        public string Code { get; set; }

        /// <summary>Matérias que compõem o curso.</summary>    
        public IEnumerable<Materia> Materias { get; set; }
    }
}
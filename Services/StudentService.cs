using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDbExample.Models;

namespace MongoDbExample.Services
{
    /// <summary></summary>
    public class StudentService
    {
        /// <summary></summary>
        private readonly IMongoCollection<Student> _students;
        
        /// <summary></summary>
        public StudentService(ISchoolDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }
        
        /// <summary></summary>
        public async Task<List<Student>> GetAllAsync()
        {
            return await _students.Find(s => true).ToListAsync();
        }
        
        /// <summary></summary>
        public async Task<Student> GetByIdAsync(string id)
        {
            return await _students.Find<Student>(s => s.Id == id).FirstOrDefaultAsync();
        }
        
        /// <summary></summary>
        public async Task<Student> CreateAsync(Student student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }
        
        /// <summary></summary>
        public async Task UpdateAsync(string id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }
        
        /// <summary></summary>
        public async Task DeleteAsync(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
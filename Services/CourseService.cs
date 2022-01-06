using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDbExample.Models;

namespace MongoDbExample.Services
{
    /// <summary></summary>
    public class CourseService
    {
        /// <summary></summary>
        private readonly IMongoCollection<Course> _courses;

        /// <summary></summary>
        public CourseService(ISchoolDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _courses = database.GetCollection<Course>(settings.CoursesCollectionName);
        }

        /// <summary></summary>
        public async Task<List<Course>> GetAllAsync()
        {
            return await _courses.Find(s => true).ToListAsync();
        }

        /// <summary></summary>
        public async Task<Course> GetByIdAsync(string id)
        {
            return await _courses.Find<Course>(c => c.Id == id).FirstOrDefaultAsync();
        }

        /// <summary></summary>
        public async Task<Course> CreateAsync(Course course)
        {
            await _courses.InsertOneAsync(course);
            return course;
        }

        /// <summary></summary>
        public async Task UpdateAsync(string id, Course course)
        {
            await _courses.ReplaceOneAsync(c => c.Id == id, course);
        }

        /// <summary></summary>
        public async Task DeleteAsync(string id)
        {
            await _courses.DeleteOneAsync(c => c.Id == id);
        }
    }
}
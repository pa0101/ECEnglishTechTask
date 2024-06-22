using ECEnglishTechTask.DAL.Repositories.Interfaces;
using ECEnglishTechTask.Application.Services.Interfaces;
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;    
        }

        public IEnumerable<Course> GetCourses() => _repository.GetCourses();
    }
}
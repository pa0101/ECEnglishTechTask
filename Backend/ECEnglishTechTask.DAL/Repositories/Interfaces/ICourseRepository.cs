using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.DAL.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
    }
}
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.DAL.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseById(int courseId);
        IEnumerable<Course> GetCourses();
    }
}
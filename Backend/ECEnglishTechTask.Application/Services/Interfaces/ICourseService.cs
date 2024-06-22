using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Services.Interfaces
{
    public interface ICourseService
    {
        Course GetCourseById(int courseId);
        IEnumerable<Course> GetCourses();
    }
}
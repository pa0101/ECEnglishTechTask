using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
    }
}
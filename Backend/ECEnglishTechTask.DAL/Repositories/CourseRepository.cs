using ECEnglishTechTask.Core.Entities;
using ECEnglishTechTask.DAL.Repositories.Interfaces;

namespace ECEnglishTechTask.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ECEnglishContext _context;

        public CourseRepository(ECEnglishContext context)
        {
            _context = context;

            if (!_context.Courses.Any()) GenerateCourses(6);            
        }

        public Course GetCourseById(int courseId) => _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

        public IEnumerable<Course> GetCourses() => _context.Courses;

        private void GenerateCourses(int numberOfCourses)
        {
            var courses = new List<Course>();
            var currentStartDate = GetNextMonday(DateTime.Today);

            for (int i = 1; i <= numberOfCourses; i++)
            {
                var startDate = currentStartDate;
                var endDate = startDate.AddDays(4);
                courses.Add(new Course
                {
                    CourseId = i,
                    Name = $"English {i}",
                    StartDate = startDate,
                    EndDate = endDate
                });

                currentStartDate = GetNextMonday(endDate.AddDays(1));
            }

            _context.Courses.AddRange(courses);
            _context.SaveChanges();
        }

        private static DateTime GetNextMonday(DateTime date)
        {
            var daysUntilMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilMonday);
        }
    }
}
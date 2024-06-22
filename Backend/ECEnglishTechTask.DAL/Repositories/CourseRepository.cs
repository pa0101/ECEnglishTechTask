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

            if (!_context.Courses.Any()) GenerateCourseData(numberOfWeeks:3, numberOfCourses:6);            
        }

        public IEnumerable<Course> GetCourses() => _context.Courses;

        private void GenerateCourseData(int numberOfWeeks, int numberOfCourses)
        {
            var courses = new List<Course>();
            var currentStartDate = GetNextMonday(DateTime.Today);

            for (int i = 0; i < numberOfWeeks; i++)
            {
                DateTime endDate = new();
                for (int j = 1; j <= numberOfCourses; j++)
                {
                    var startDate = currentStartDate;
                    endDate = startDate.AddDays(4);
                    courses.Add(new Course
                    {
                        Name = $"English {j} {startDate:dd-MM-yyyy} - {endDate:dd-MM-yyyy}",
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

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
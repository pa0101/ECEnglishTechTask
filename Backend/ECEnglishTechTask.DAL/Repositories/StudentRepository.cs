using ECEnglishTechTask.Core.Entities;
using ECEnglishTechTask.Core.Enums;
using ECEnglishTechTask.DAL.Repositories.Interfaces;

namespace ECEnglishTechTask.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ECEnglishContext _context;

        public StudentRepository(ECEnglishContext context)
        {
            _context = context;
        }

        public Student AddStudent(Student student)
        {
            student.Status = (int)StudentStatus.Enrolled;

            foreach (var enrollment in student.CourseEnrollments)
            {
                enrollment.Status = (int)CourseEnrollmentStatus.Active;
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            
            return student;
        }
    }
}
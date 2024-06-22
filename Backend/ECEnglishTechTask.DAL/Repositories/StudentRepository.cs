using ECEnglishTechTask.Core.Entities;
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
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
    }
}
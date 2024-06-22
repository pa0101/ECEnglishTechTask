using ECEnglishTechTask.Application.Services.Interfaces;
using ECEnglishTechTask.Core.Entities;
using ECEnglishTechTask.DAL.Repositories.Interfaces;

namespace ECEnglishTechTask.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;    
        }

        public Student AddStudent(Student student) => _repository.AddStudent(student);
    }
}
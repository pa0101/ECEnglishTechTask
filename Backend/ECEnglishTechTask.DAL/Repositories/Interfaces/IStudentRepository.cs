using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student AddStudent(Student student);
    }
}
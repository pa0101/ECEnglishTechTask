using ECEnglishTechTask.Application.Inputs;
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Student AddStudent(StudentInput input);
    }
}
using AutoMapper;
using ECEnglishTechTask.Application.Inputs;
using ECEnglishTechTask.Application.Services.Interfaces;
using ECEnglishTechTask.Core.Entities;
using ECEnglishTechTask.DAL.Repositories.Interfaces;

namespace ECEnglishTechTask.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public Student AddStudent(StudentInput input) =>
            _repository.AddStudent(_mapper.Map<Student>(input));
    }
}
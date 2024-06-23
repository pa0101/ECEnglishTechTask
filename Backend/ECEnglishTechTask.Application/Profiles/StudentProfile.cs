using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Application.Inputs;
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentInput, Student>();
        }
    }
}
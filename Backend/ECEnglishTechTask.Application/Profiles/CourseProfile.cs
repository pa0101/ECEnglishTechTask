using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
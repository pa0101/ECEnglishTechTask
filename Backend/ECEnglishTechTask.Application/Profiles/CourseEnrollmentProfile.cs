using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Core.Entities;

namespace ECEnglishTechTask.Application.Profiles
{
    public class CourseEnrollmentProfile : Profile
    {
        public CourseEnrollmentProfile()
        {
            CreateMap<CourseEnrollment, CourseEnrollmentDto>();
        }
    }
}
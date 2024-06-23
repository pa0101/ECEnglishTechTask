namespace ECEnglishTechTask.Application.Dtos
{
    public class StudentDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public IEnumerable<CourseEnrollmentDto> CourseEnrollments { get; set; }
    }
}
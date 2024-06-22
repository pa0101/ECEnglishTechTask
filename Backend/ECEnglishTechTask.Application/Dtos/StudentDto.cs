namespace ECEnglishTechTask.Application.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<CourseEnrollmentDto> CourseEnrollments { get; set; }
    }
}
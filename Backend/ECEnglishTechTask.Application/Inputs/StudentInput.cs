namespace ECEnglishTechTask.Application.Inputs
{
    public class StudentInput : BaseInput
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Status { get; set; }
        public IEnumerable<CourseEnrollmentInput> CourseEnrollments { get; set; }
    }
}
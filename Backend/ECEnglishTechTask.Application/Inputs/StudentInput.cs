namespace ECEnglishTechTask.Application.Inputs
{
    public class StudentInput : BaseInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public IEnumerable<CourseEnrollmentInput> CourseEnrollments { get; set; } = new List<CourseEnrollmentInput>();
    }
}
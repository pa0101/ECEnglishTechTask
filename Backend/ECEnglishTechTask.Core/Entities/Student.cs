namespace ECEnglishTechTask.Core.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public IEnumerable<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
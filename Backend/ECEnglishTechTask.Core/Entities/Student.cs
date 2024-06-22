namespace ECEnglishTechTask.Core.Entities
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
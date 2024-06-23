namespace ECEnglishTechTask.Application.Inputs
{
    public class CourseEnrollmentInput
    {
        public int CourseEnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
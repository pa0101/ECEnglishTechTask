namespace ECEnglishTechTask.Application.Inputs
{
    public class CourseEnrollmentInput : BaseInput
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
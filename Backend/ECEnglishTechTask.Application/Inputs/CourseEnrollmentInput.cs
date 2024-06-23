namespace ECEnglishTechTask.Application.Inputs
{
    public class CourseEnrollmentInput : BaseInput
    {
        public required int CourseId { get; set; }
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
    }
}
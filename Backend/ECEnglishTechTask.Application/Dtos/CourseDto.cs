namespace ECEnglishTechTask.Application.Dtos
{
    public class CourseDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
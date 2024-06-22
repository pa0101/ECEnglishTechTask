using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECEnglishTechTask.Core.Entities
{
    public class CourseEnrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseEnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
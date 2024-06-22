using ECEnglishTechTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECEnglishTechTask.DAL
{
    public class ECEnglishContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        
        public ECEnglishContext(DbContextOptions<ECEnglishContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.CourseEnrollments)
                .WithOne()
                .HasForeignKey(ce => ce.StudentId);
        }
    }
}
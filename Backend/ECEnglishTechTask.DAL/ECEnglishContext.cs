using ECEnglishTechTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECEnglishTechTask.DAL
{
    public class ECEnglishContext : DbContext
    {
        public ECEnglishContext(DbContextOptions<ECEnglishContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ECEnglishDb");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
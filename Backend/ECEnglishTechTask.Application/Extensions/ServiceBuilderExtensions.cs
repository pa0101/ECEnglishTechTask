using ECEnglishTechTask.DAL;
using ECEnglishTechTask.DAL.Repositories;
using ECEnglishTechTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECEnglishTechTask.Application.Extensions
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceCollection RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECEnglishContext>(option =>
                option.UseInMemoryDatabase(configuration.GetSection("InMemoryDatabaseName").Value));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            return services;
        }
    }
}
using AutoMapper;
using Moq;
using Xunit;
using ECEnglishTechTask.Application.Inputs;
using ECEnglishTechTask.Application.Services;
using ECEnglishTechTask.Application.Services.Interfaces;
using ECEnglishTechTask.Core.Entities;
using ECEnglishTechTask.DAL.Repositories.Interfaces;

namespace ECEnglishTechTask.Test;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _mockRepository = new Mock<IStudentRepository>();
        _mockMapper = new Mock<IMapper>();
        _studentService = new StudentService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public void AddStudent_ShouldReturnAddedStudent()
    {
        // Arrange
        var studentInput = new StudentInput
        {
            FirstName = "Paolo",
            LastName = "Di Pietro",
            Email = "john.dipietro@test.com"
        };

        var student = new Student
        {
            FirstName = "Paolo",
            LastName = "Di Pietro",
            Email = "john.dipietro@test.com"
        };

        _mockMapper.Setup(m => m.Map<Student>(It.IsAny<StudentInput>())).Returns(student);
        _mockRepository.Setup(r => r.AddStudent(It.IsAny<Student>())).Returns(student);

        // Act
        var result = _studentService.AddStudent(studentInput);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(student.FirstName, result.FirstName);
        Assert.Equal(student.LastName, result.LastName);
        Assert.Equal(student.Email, result.Email);

        _mockMapper.Verify(m => m.Map<Student>(It.IsAny<StudentInput>()), Times.Once);
        _mockRepository.Verify(r => r.AddStudent(It.IsAny<Student>()), Times.Once);
    }
}
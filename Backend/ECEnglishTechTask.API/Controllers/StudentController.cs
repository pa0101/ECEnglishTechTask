using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Application.Services.Interfaces;
using ECEnglishTechTask.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace ECEnglishTechTask.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IMapper _mapper;
    private readonly IStudentService _service;

    public StudentController(ILogger<StudentController> logger, IMapper mapper, IStudentService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    [Route("AddStudent")]
    public IActionResult AddStudent(Student student)
    {
        _logger.LogInformation("Adding student");

        student = _service.AddStudent(student);

        return Ok(_mapper.Map<StudentDto>(student));
    }
}

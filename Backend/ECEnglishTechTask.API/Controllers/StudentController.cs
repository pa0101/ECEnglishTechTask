using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Application.Inputs;
using ECEnglishTechTask.Application.Services.Interfaces;
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
    public IActionResult AddStudent(StudentInput input)
    {
        _logger.LogInformation("Adding student");

        return Ok(_mapper.Map<StudentDto>(_service.AddStudent(input)));
    }
}

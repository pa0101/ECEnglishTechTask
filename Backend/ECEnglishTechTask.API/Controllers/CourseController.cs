using System.Collections.Generic;
using AutoMapper;
using ECEnglishTechTask.Application.Dtos;
using ECEnglishTechTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECEnglishTechTask.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly IMapper _mapper;
    private readonly ICourseService _service;

    public CourseController(ILogger<CourseController> logger, IMapper mapper, ICourseService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    [Route("GetCourses")]
    public IActionResult GetCourses()
    {
        _logger.LogInformation("Getting all courses");

        var courses = _service.GetCourses();

        return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
    }
}

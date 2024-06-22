using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECEnglishTechTask.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }
}

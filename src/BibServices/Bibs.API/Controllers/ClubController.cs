using Microsoft.AspNetCore.Mvc;

namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClubController : ControllerBase
{
    private readonly ILogger<ClubController> _logger;

    public ClubController(ILogger<ClubController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Alive");
    }
}

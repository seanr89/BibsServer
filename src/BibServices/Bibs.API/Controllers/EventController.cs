using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly AppDbContext _context;

    public EventController(ILogger<EventController> logger,
        AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Alive");
    }
}

using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger,
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

    /// <summary>
    /// Additional End-point to test Db connectivity
    /// </summary>
    /// <returns>ActionResult message</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("DbContext")]
    public async Task<IActionResult> CheckDbContext()
    {
        try{
            var res = await _context.Database.CanConnectAsync();
            if(res)
                return Ok();
        }catch(Exception e)
        {
            Console.WriteLine($"Exception: {e.Message} caught");
        }
        
        return BadRequest();
    }
}

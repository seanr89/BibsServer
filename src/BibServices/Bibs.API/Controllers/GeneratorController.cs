using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GeneratorController : ControllerBase
{
    private readonly ILogger<GeneratorController> _logger;
    private readonly TeamGenerator _generator;

    public GeneratorController(ILogger<GeneratorController> logger,
        TeamGenerator generator)
    {
        _logger = logger;
        _generator = generator;
    }

    [HttpPost]
    public async Task<IActionResult> Generate(List<Member> members)
    {
        throw new NotImplementedException());
        //return BadRequest("Save failed");
    }
}

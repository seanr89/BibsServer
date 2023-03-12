using Application.Services;
using Bibs.API.DTOs;
using Domain;
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
    [ProducesResponseType(typeof(IEnumerable<Team>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Generate(List<Member> memberDTOs)
    {
        // List<Member> members = new List<Member>();
        // memberDTOs.ForEach(m => {
        //     members.Add((Member)m);
        // });

        var res = _generator.Generate(memberDTOs);
        if(res != null)
            return Ok(res);
        
        return BadRequest("Generate failed");
    }
}

using Application.Services;
using Bibs.API.DTOs;
using Domain;
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
    public async Task<IActionResult> Generate(List<MemberDTO> memberDTOs)
    {
        List<Member> members = new List<Member>();
        memberDTOs.ForEach(m => {
            members.Add((Member)m);
        });

        var res = _generator.Generate(members);
        if(res != null)
            return Ok(res);
        
        return BadRequest("Generate failed");
    }
}

using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly MemberService _service;
    public MemberController(MemberService service)
    {
        _service = service;
    }

    /// <summary>
    /// Query all members
    /// </summary>
    /// <returns>Collection of Member records</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Member>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllMembers();
        if (result.Any())
            return Ok(result);

        return NotFound("No records found");
    }

    /// <summary>
    /// Query a single member
    /// </summary>
    /// <param name="id">unique Id of the member</param>
    /// <returns></returns>
    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Member>> GetByID(Guid id)
    {
        var result = await _service.GetMemberById(id);
        if (result != null)
            return Ok(result);

        return NotFound("No record found");
    }
}

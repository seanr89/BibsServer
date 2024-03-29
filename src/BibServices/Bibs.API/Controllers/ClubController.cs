using Application.Services;
using Bibs.API.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClubController : ControllerBase
{
    private readonly ClubService _clubService;
    public ClubController(ClubService clubService)
    {
        _clubService = clubService;
    }

    /// <summary>
    /// Query all clubs
    /// </summary>
    /// <returns>Collection of ClubDTO records</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Club>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var result = await _clubService.GetAllClubs();
        if (result.Any())
            return Ok(result);

        return NotFound("No records found");
    }

    /// <summary>
    /// Query a single club
    /// </summary>
    /// <param name="id">unique Id of the club</param>
    /// <returns></returns>
    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Club>> GetByID(Guid id)
    {
        var result = await _clubService.GetClubById(id);
        if (result != null)
            return Ok(result);

        return NotFound("No club found");
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateClubDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateClubDTO dto)
    {
        var club = (Club)dto;
        var result = await _clubService.CreateClub(club);
        if (result != Guid.Empty)
            return CreatedAtRoute("GetById", new { id = result }, club);

        return BadRequest("Save failed");
    }
}

using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Application service for interacting with clubs
/// </summary>
public sealed class ClubService
{
    private readonly ILogger<ClubService> _logger;
    public ClubService(ILogger<ClubService> logger)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        _logger = logger;
    }

    public IEnumerable<Club> GetAllClubs()
    {
        throw new NotImplementedException();
    }

    public Club GetClubById(string id)
    {
        throw new NotImplementedException();
    }

    public string CreateClub(Club club)
    {
        throw new NotImplementedException();
    }
}
using Domain;
using Infrastructure.Repos;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Application service for interacting with clubs
/// </summary>
public sealed class ClubService
{
    private readonly ILogger<ClubService> _logger;
    private readonly IClubsRepository _clubsRepository;
    public ClubService(ILogger<ClubService> logger, IClubsRepository clubsRepository)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        _logger = logger;
        _clubsRepository = clubsRepository;
    }

    public async Task<IEnumerable<Club>> GetAllClubs()
    {
        return await _clubsRepository.GetAllClubsAsync();
    }

    public async Task<Club> GetClubById(Guid id)
    {
        return await _clubsRepository.GetClubAsync(id);
    }

    public string CreateClub(Club club)
    {
        throw new NotImplementedException();
    }
}
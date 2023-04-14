using Domain;
using Infrastructure.Repos;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Application service for interacting with repos and infra
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

    public async Task<IEnumerable<Club>> GetAllClubs() => await _clubsRepository.GetAllClubsAsync();

    public async Task<Club?> GetClubById(Guid id) => await _clubsRepository.GetClubAsync(id);

    public async Task<Guid> CreateClub(Club club)
    {
        var result = await _clubsRepository.CreateClubAsync(club);
        if (result > 0)
        {
            return club.Id;
        }
        return Guid.Empty;
    }
}
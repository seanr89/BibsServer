
using Domain;

namespace Infrastructure.Repos;

public interface IClubsRepository
{
    Task<IEnumerable<Club>> GetAllClubsAsync();
    Task<IEnumerable<Club>> GetActiveClubsAsync();
    Task<Club> GetClubAsync(Guid id);
    Task<int> CreateClubAsync(Club club);
}
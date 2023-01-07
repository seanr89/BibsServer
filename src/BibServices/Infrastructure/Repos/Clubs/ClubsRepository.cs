
using Domain;

namespace Infrastructure.Repos;

public class ClubsRepository : IClubsRepository
{
    public Task<IEnumerable<Club>> GetActiveClubsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Club>> GetAllClubsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Club> GetClubAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
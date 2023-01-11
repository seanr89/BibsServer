
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class ClubsRepository : IClubsRepository
{
    private readonly AppDbContext _context;
    public ClubsRepository(AppDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context, "dbContext");
        _context = context;
    }

    public async Task<IEnumerable<Club>> GetActiveClubsAsync()
    {
        return await _context.Clubs.Where(c => c.Active == true).ToListAsync();
    }

    public async Task<IEnumerable<Club>> GetAllClubsAsync()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetClubAsync(Guid id) => await _context.Clubs.FirstOrDefaultAsync(c => c.Id == id);
}
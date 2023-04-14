
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;
    public MemberRepository(AppDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context, "context");
        _context = context;
    }

    public async Task<int> CreateAsync(Member member)
    {
        _context.Members.Add(member);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<IEnumerable<Member>> GetActiveMembersAsync() => await _context.Members.Where(c => c.Active == true).ToListAsync();

    public async Task<IEnumerable<Member>> GetAllMembersAsync() => await _context.Members.ToListAsync();

    public async Task<Member?> GetMemberAsync(Guid id) => await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
}
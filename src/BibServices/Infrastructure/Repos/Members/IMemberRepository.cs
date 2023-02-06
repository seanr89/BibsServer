
using Domain;

namespace Infrastructure.Repos;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembersAsync();
    Task<IEnumerable<Member>> GetActiveMembersAsync();
    Task<Member?> GetMemberAsync(Guid id);
    Task<int> CreateAsync(Member member);
}
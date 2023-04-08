using Domain;
using Infrastructure.Repos;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Application service for interacting with repos and infra
/// Members accessibility
/// </summary>
public sealed class MemberService
{
    private readonly ILogger<MemberService> _logger;
    private readonly IMemberRepository _memberRepo;
    public MemberService(ILogger<MemberService> logger, IMemberRepository memberRepo)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        _logger = logger;
        _memberRepo = memberRepo;
    }

    public async Task<IEnumerable<Member>> GetAllMembers() => await _memberRepo.GetAllMembersAsync();

    public async Task<Member?> GetMemberById(Guid id) => await _memberRepo.GetMemberAsync(id);

    public async Task<int> CreateMember(Member membr) => await _memberRepo.CreateAsync(membr);
}
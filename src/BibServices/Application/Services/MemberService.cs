using Domain;
using Infrastructure.Repos;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Application service for interacting with repos and infra
/// </summary>
public sealed class MemberService
{
    private readonly ILogger<MemberService> _logger;
    public MemberService(ILogger<MemberService> logger)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        _logger = logger;
    }

    public async Task<IEnumerable<Member>> GetAllMembers()
    {
        throw new NotImplementedException();
    }

    public async Task<Member?> GetMemberById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateMember(Member membr)
    {
        throw new NotImplementedException();
    }
}
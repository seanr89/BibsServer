
using Domain;
using Microsoft.Extensions.Logging;
using Utils;

namespace Application.Services;

public class TeamGenerator
{
    private readonly ILogger<TeamGenerator> _logger;
    public TeamGenerator(ILogger<TeamGenerator> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="members"></param>
    /// <returns></returns>
    public async Task<List<Team>> Generate(List<Member> members)
    {
        if(!members.Any())
            return null;

        HelperMethods.Shuffle<Member>(members);
        var divSize = Convert.ToInt32(members.Count / 2);
        var splitList = HelperMethods.SplitList(members, divSize).ToList();

        var teamOne = new Team("Team 1");
        var teamTwo = new Team("Team 2");

        teamOne.AddPlayersByMembers(splitList[0]);
        teamOne.AddPlayersByMembers(splitList[1]);

        var response = new List<Team>();
        response.Add(teamOne);
        response.Add(teamTwo);
        return response;
    }
}

namespace Application.Services;

public class TeamGenerator
{
    private readonly ILogger<TeamGenerator> _logger;
    public TeamGenerator(ILogger<TeamGenerator> logger)
    {
        _logger = logger;
    }

    public async Task Generate(List<Members> members)
    {
        if(!members.Any())
            return;

        
    }
}
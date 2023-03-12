namespace Domain;

/// <summary>
/// Planned entity for detailing someone who played a matched
/// </summary>
public class Team
{

    // public Guid Id { get; set; }
    public string Name { get; set; }
    private List<Player> players {get; set; }

    public Team()
    {
    }

    public Team(string name)
    {
        this.Name = name;
    }

    #region Player

    public void AddPlayersByMembers(List<Member> members)
    {
        if(!members.Any())
            return;

        members.ForEach(m => {
            this.players.Add(ConvertMemberToPlayer(m));
        });
    }

    Player ConvertMemberToPlayer(Member member)
    {
        return new Player()
        {
            Name = member.Name,
            Email = member.Email,
            Rating = member.BaseRating
        };
    }

    #endregion

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
    }

    #endregion
}
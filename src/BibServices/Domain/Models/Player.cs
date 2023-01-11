namespace Domain;

/// <summary>
/// A record of someone who plays
/// </summary>
public record Player
{

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public Player()
    {
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
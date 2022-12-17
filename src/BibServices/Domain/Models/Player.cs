namespace Domain;

/// <summary>
/// 
/// </summary>
public record Player
{

    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }

    public Player()
    {
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
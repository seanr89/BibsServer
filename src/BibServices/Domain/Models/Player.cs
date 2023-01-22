namespace Domain;

/// <summary>
/// A record of someone who plays
/// </summary>
public class Player : AuditableEntity
{

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public bool Active { get; private set; }
    /// <summary>
    /// Details for the specific club
    /// </summary>
    /// <value></value>
    public Club Club { get; set; }

    public Player()
    {
    }

    #region Setters

    public void Activate() => this.Active = true;
    public void DeActivate() => this.Active = false;

    #endregion

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
    }

    #endregion
}